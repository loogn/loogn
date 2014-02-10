using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Common;
using System.Data;
using Loogn.DB;
using System.Dynamic;
using System.Reflection;


namespace Loogn.DB
{
    public abstract class DBServer: IDisposable
    {
        #region 字段、构造及静态构造
        private DbConnection Conn;
        public string ConnStr { get; set; }
        protected DBServer(string conn, ConnType type)
        {
            if (type == ConnType.ConnName)
            {
                if (string.IsNullOrEmpty(conn))
                {
                    if (string.IsNullOrEmpty(DefaultConnStr))
                        throw new Exception("默认构造为使用配置文件ConnectionStrings的第一个结点，现在没给出");
                    else
                        ConnStr = DefaultConnStr;
                }
                else
                {
                    ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings[conn].ConnectionString;
                }
            }
            else if (type == ConnType.ConnString)
            {
                ConnStr = conn;
            }
            else
            {
                throw new Exception("什么？出错了！无此ConnType");
            }
        }

        static string DefaultConnStr;//取ConnectionStrings的第一个
        static DBServer()
        {
            var connStrs = System.Configuration.ConfigurationManager.ConnectionStrings;
            if (connStrs.Count > 0)
                DefaultConnStr = connStrs[0].ConnectionString;
        }
        #endregion


        #region 得到具体子类实例
        public static SqlServer GetSqlServer(string conn = "", ConnType type = ConnType.ConnName)
        {
            return SqlServer.GetInstance(conn, type);
        }
        public static OdbcServer GetOdbcServer(string conn = "", ConnType type = ConnType.ConnName)
        {
            return OdbcServer.GetInstance(conn, type);
        }
        public static OleDbServer GetOleDbServer(string conn = "", ConnType type = ConnType.ConnName)
        {
            return OleDbServer.GetInstance(conn, type);
        }
        #endregion

        
        #region ado.net对象多态化子类实现
        protected abstract DbConnection GetConn();
        protected abstract DbParameter GetParameter();
        protected abstract DbDataAdapter GetAdpt();
        #endregion


        private DbCommand GetCmdAndOpenConn(string text, CommandType type, DbTransaction trans, DbParameter[] parameters)
        {
            Open();
            var cmd = Conn.CreateCommand();
            cmd.CommandTimeout = 180;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.Connection = Conn;
            cmd.CommandText = text;
            cmd.CommandType = type;
            if (parameters != null)
            {
                foreach (var parm in parameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }

            return cmd;
        }
         
        public static void DbReaderToDict(IDictionary<string, object> dict, DbDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dict.Add(reader.GetName(i), reader.GetValue(i));
            }
        }
        
        public static T DbReaderToObj<T>(DbDataReader reader)
        {
            T obj = Activator.CreateInstance<T>();
            var type = obj.GetType();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var prop = type.GetProperty(reader.GetName(i), System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (null != prop)
                {
                    var value = reader.GetValue(i);
                    if (null == value || value is DBNull)
                        prop.SetValue(obj, null, null);
                    else
                        prop.SetValue(obj, value, null);
                }
            }
            return obj;
        }



        public static DbParameter[] CopyParameters(params DbParameter[] parames)
        {
            DbParameter[] ps = new DbParameter[parames.Length];
            for (int i = 0; i < parames.Length; i++)
            {
                ps[i] = (DbParameter)((ICloneable)parames[i]).Clone();
            }
            return ps;
        }

        
        #region 创建参数方法
        public DbParameter CreateParameter(string parameterName, object value)
        {
            var parameter = GetParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            return parameter;
        }
        public DbParameter CreateParameter(string parameterName, DbType type, ParameterDirection direction)
        {
            var parameter = GetParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = type;
            parameter.Direction = direction;
            return parameter;
        }
        #endregion


        #region ExecuteNonQuery
        public int ExecuteNonQuery(string text, CommandType type, params DbParameter[] parameters)
        {
            return ExecuteNonQuery(text, type, null, parameters);
        }
        public int ExecuteNonQuery(string text, CommandType type, DbTransaction trans, params DbParameter[] parameters)
        {
            var cmd = GetCmdAndOpenConn(text, type,trans, parameters);
            return cmd.ExecuteNonQuery();
        }
        public int ExecuteNonQuery(string text,DbTransaction trans, params DbParameter[] parameters)
        {
            return ExecuteNonQuery(text, CommandType.Text, trans, parameters);
        }
        public int ExecuteNonQuery(string text, params DbParameter[] parameters)
        {
            return ExecuteNonQuery(text, null, parameters);
        }
        #endregion


        #region ExecuteScalar
        public object ExecuteScalar(string text, CommandType type, params DbParameter[] parameters)
        {
            return ExecuteScalar(text, type, null, parameters);
        }
        public object ExecuteScalar(string text, CommandType type, DbTransaction trans, params DbParameter[] parameters)
        {
            var cmd = GetCmdAndOpenConn(text, type,trans, parameters);
            return cmd.ExecuteScalar();
        }
        public object ExecuteScalar(string text,  params DbParameter[] parameters)
        {
            return ExecuteScalar(text, CommandType.Text, parameters);
        }
        public object ExecuteScalar(string text, DbTransaction trans, params DbParameter[] parameters)
        {
            return ExecuteScalar(text, CommandType.Text, trans, parameters);
        }
        #endregion


        #region ExecuteReader
        public DbDataReader ExecuteReader(string text, CommandType type, params DbParameter[] parameters)
        {
            return ExecuteReader(text, type, null, parameters);
        }
        public DbDataReader ExecuteReader(string text, CommandType type, DbTransaction trans, params DbParameter[] parameters)
        {
            var cmd = GetCmdAndOpenConn(text, type,trans, parameters);
            return cmd.ExecuteReader();
        }
        public DbDataReader ExecuteReader(string text, params DbParameter[] parameters)
        {
            return ExecuteReader(text, CommandType.Text, null, parameters);
        }
        public DbDataReader ExecuteReader(string text, DbTransaction trans, params DbParameter[] parameters)
        {
            return ExecuteReader(text, CommandType.Text, trans, parameters);
        }

        public DbDataReader SingleRow(string text, CommandType type, params DbParameter[] parameters)
        {
            return SingleRow(text, type, null, parameters);
        }
        public DbDataReader SingleRow(string text, CommandType type, DbTransaction trans, params DbParameter[] parameters)
        {
            var cmd = GetCmdAndOpenConn(text, type, trans, parameters);
            return cmd.ExecuteReader(CommandBehavior.SingleRow);
        }
        public DbDataReader SingleRow(string text, params DbParameter[] parameters)
        {
            return SingleRow(text, CommandType.Text , null, parameters);
        }
        public DbDataReader SingleRow(string text,DbTransaction trans, params DbParameter[] parameters)
        {
            return SingleRow(text, CommandType.Text, trans, parameters);
        }
        #endregion


        #region ExecuteDataSet
        public DataSet ExecuteDataSet(string text, CommandType type,params DbParameter[] parameters)
        {
            return ExecuteDataSet(text, type, null, parameters);
        }
        public DataSet ExecuteDataSet(string text, CommandType type, DbTransaction trans, params DbParameter[] parameters)
        {
            var cmd = GetCmdAndOpenConn(text, type,trans, parameters);
            var adpt = GetAdpt();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public DataSet ExecuteDataSet(string text, params DbParameter[] parameters)
        {
            return ExecuteDataSet(text, CommandType.Text, null, parameters);
        }
        public DataSet ExecuteDataSet(string text, DbTransaction trans, params DbParameter[] parameters)
        {
            return ExecuteDataSet(text, CommandType.Text, trans, parameters);
        }
        #endregion


        #region ExecuteDataTable
        public DataTable ExecuteDataTable(string text, CommandType type, params DbParameter[] parameters)
        {
            return ExecuteDataTable(text, type, null, parameters);
        }
        public DataTable ExecuteDataTable(string text, CommandType type, DbTransaction trans, params DbParameter[] parameters)
        {
            var cmd = GetCmdAndOpenConn(text, type, trans, parameters);
            var adpt = GetAdpt();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
        }
        public DataTable ExecuteDataTable(string text, params DbParameter[] parameters)
        {
            return ExecuteDataTable(text, CommandType.Text, null, parameters);
        }
        public DataTable ExecuteDataTable(string text, DbTransaction trans, params DbParameter[] parameters)
        {
            return ExecuteDataTable(text, CommandType.Text, trans, parameters);
        }
        #endregion


        #region BeginTransaction
        public DbTransaction BeginTransaction()
        {
            return Conn.BeginTransaction();
        }
        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return Conn.BeginTransaction(isolationLevel);
        }
        #endregion


        #region 便捷操作
        public dynamic ExecuteModel(string text, CommandType type, params DbParameter[] parameters)
        {
            using (var reader = ExecuteReader(text, type, parameters))
            {
                if (reader.Read())
                {
                    var eo = new ExpandoObject();
                    DbReaderToDict(eo, reader);
                    return eo;
                }
                return null;
            }
        }
        public dynamic ExecuteModel(string text, params DbParameter[] parameters)
        {
            return ExecuteModel(text, CommandType.Text, parameters);
        }
        public T ExecuteModel<T>(string text, CommandType type, params DbParameter[] parameters)
        {
            using (var reader = ExecuteReader(text, type, parameters))
            {
                if (reader.Read())
                {
                    return DbReaderToObj<T>(reader);
                }
                return default(T);
            }
        }
        public T ExecuteModel<T>(string text, params DbParameter[] parameters)
        {
            return ExecuteModel<T>(text, CommandType.Text, parameters);
        }

        public Dictionary<int, List<dynamic>> ExecuteModelsDict(string text, CommandType type, params DbParameter[] parameters)
        {
            using (var reader = ExecuteReader(text, type, parameters))
            {
                var dict = new Dictionary<int, List<dynamic>>();
                int index = 0;
                List<dynamic> curList;
            FullOneList://这里用了goto， 罪过罪过！
                while (reader.Read())
                {
                    if (!dict.TryGetValue(index, out curList))
                    {
                        curList = new List<dynamic>();
                        dict[index] = curList;
                    }
                    var eo = new ExpandoObject();
                    DbReaderToDict(eo, reader);
                    curList.Add(eo);
                }
                if (reader.NextResult())
                {
                    index++;
                    goto FullOneList;
                }
                return dict;
            }
        }
        public Dictionary<int, List<dynamic>> ExecuteModelsDict(string text, params DbParameter[] parameters)
        {
            return ExecuteModelsDict(text, CommandType.Text, parameters);
        }
        public Dictionary<int, List<T>> ExecuteModelsDict<T>(string text, CommandType type, params DbParameter[] parameters)
        {
            using (var reader = ExecuteReader(text, type, parameters))
            {
                var dict = new Dictionary<int, List<T>>();
                int index = 0;
                List<T> curList;
            FullOneList://这里用了goto， 罪过罪过！
                while (reader.Read())
                {
                    if (!dict.TryGetValue(index, out curList))
                    {
                        curList = new List<T>();
                        dict[index] = curList;
                    }
                    var obj = DbReaderToObj<T>(reader);
                    curList.Add(obj);
                }
                if (reader.NextResult())
                {
                    index++;
                    goto FullOneList;
                }
                return dict;
            }
        }
        public Dictionary<int, List<T>> ExecuteModelsDict<T>(string text, params DbParameter[] parameters)
        {
            return ExecuteModelsDict<T>(text, CommandType.Text, parameters);
        }
        
        public List<dynamic> ExecuteModels(string text, CommandType type, params DbParameter[] parameters)
        {
            using (var reader = ExecuteReader(text, type,null, parameters))
            {
                List<dynamic> list = new List<dynamic>();
                while (reader.Read())
                {
                    var eo = new ExpandoObject();
                    
                    DbReaderToDict(eo, reader);
                    list.Add(eo);
                }
                return list;
            }
        }
        public List<dynamic> ExecuteModels(string text, params DbParameter[] parameters)
        {
            return ExecuteModels(text, CommandType.Text, parameters);
        }
        public List<T> ExecuteModels<T>(string text, CommandType type, params DbParameter[] parameters)
        {
            using (var reader = ExecuteReader(text, type, null, parameters))
            {
                List<T> list = new List<T>();
                while (reader.Read())
                {
                    var obj= DbReaderToObj<T>(reader);
                    list.Add(obj);
                }
                return list;
            }
        }
        public List<T> ExecuteModels<T>(string text, params DbParameter[] parameters)
        {
            return ExecuteModels<T>(text, CommandType.Text, parameters);
        }

        public virtual dynamic SelectOne(string table, string fields, string condition, params DbParameter[] parameters)
        {
            var list = Select(table, 1, fields, condition, parameters);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }
        public virtual T SelectOne<T>(string table, string fields, string condition, params DbParameter[] parameters)
        {
            var list = Select<T>(table, 1, fields, condition, parameters);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return default(T);
            }
        }

        private string GetSelectSQL(string tables, int top, string fields, string condition, string orderby)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
            if (top > 0)
            {
                sb.AppendFormat("select top {0} {1} from {2}", top, fields, tables);
            }
            else
            {
                sb.AppendFormat("select {0} from {1}", fields, tables);
            }
            if (!string.IsNullOrEmpty(condition))
            {
                sb.AppendFormat(" where {0}", condition);
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                sb.AppendFormat(" order by {0}", orderby);
            }
            return sb.ToString();
        }
        public virtual List<dynamic> Select(string tables, int top, string fields, string condition, string orderby, params DbParameter[] parameters)
        {
            var rows = ExecuteModels(GetSelectSQL(tables, top, fields, condition, orderby), CommandType.Text, parameters);
            return rows;
        }
        public virtual List<dynamic> Select(string tables, string fields, string condition, params DbParameter[] parameters)
        {
            return Select(tables, 0, fields, condition, null, parameters);
        }
        public virtual List<dynamic> Select(string tables, int top, string fields, string condition, params DbParameter[] parameters)
        {
            return Select(tables, top, fields, condition, null, parameters);
        }
        public virtual List<T> Select<T>(string tables, int top, string fields, string condition, string orderby, params DbParameter[] parameters)
        {
            var rows = ExecuteModels<T>(GetSelectSQL(tables, top, fields, condition, orderby), CommandType.Text, parameters);
            return rows;
        }
        public virtual List<T> Select<T>(string tables, string fields, string condition, params DbParameter[] parameters)
        {
            return Select<T>(tables, 0, fields, condition, null, parameters);
        }
        public virtual List<T> Select<T>(string tables, int top, string fields, string condition, params DbParameter[] parameters)
        {
            return Select<T>(tables, top, fields, condition, null, parameters);
        }

        public virtual int Insert(string table,dynamic model,DbTransaction trans=null)
        {
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentException("table不能是空和null，找不到对应的表插入");
            }
            var dict = model as IDictionary<string, object>;
            if (dict == null)
            {
                object instance = model;
                var x = new System.Dynamic.ExpandoObject();
                var values =
                    from property in instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    where property.GetCustomAttributes(typeof(InsertIgnoreAttribute), true).Length == 0
                    select new
                    {
                        Name = property.Name,
                        Value = property.GetValue(instance, null)
                    };
                foreach (var property in values)
                    (x as IDictionary<string, object>).Add(property.Name, property.Value);
                dict = x;
            }
            int fieldCount = dict.Count;
            if (fieldCount <= 0)
            {
                throw new ArgumentException("model里没有字段，无法插入");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into {0} (", table);
            int i = 0;
            foreach (var name in dict.Keys)
            {
                sb.Append(name);
                if (i < fieldCount - 1)
                {
                    sb.Append(",");
                }
                i++;
            }
            sb.Append(") values (");
            i = 0;
            foreach (var name in dict.Keys)
            {
                sb.AppendFormat("@{0}", name);
                if (i < fieldCount - 1)
                {
                    sb.Append(",");
                }
                i++;
            }
            sb.Append(")");
            i = 0;
            var ps = new DbParameter[fieldCount];
            foreach (var kv in dict)
            {
                var p = GetParameter();
                p.ParameterName = kv.Key;
                p.Value = kv.Value ?? DBNull.Value;
                ps[i++] = p;
            }
            int c = ExecuteNonQuery(sb.ToString(), CommandType.Text, trans, ps);
            return c;
        }
        /// <summary>
        /// 向一个表里批量插入
        /// </summary>
        /// <param name="table"></param>
        /// <param name="models"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual int InsertBatch(string table, IEnumerable<dynamic> models, DbTransaction trans = null)
        {
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentException("table不能是空和null，找不到对应的表插入");
            }
            Open();
            if (trans == null)
                trans = BeginTransaction(IsolationLevel.ReadUncommitted);
            int sum = 0;
            try
            {
                foreach (var model in models)
                {
                    sum += Insert(table, model, trans);
                }
            }
            catch (DbException exp)
            {
                trans.Rollback();
                throw exp;
            }
            trans.Commit();
            return sum;
        }
        /// <summary>
        /// 批量插入数据，可以是向多个表插入
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public virtual int InsertBatch(IEnumerable<string> tables, IEnumerable<dynamic> models, DbTransaction trans = null)
        {
            Open();
            if (trans == null)
                trans = BeginTransaction(IsolationLevel.ReadUncommitted);
            int sum = 0;
            try
            {
                int i = 0;
                var tableArr = tables.ToArray();
                foreach (var model in models)
                {
                    sum += Insert(tableArr[i++], model, trans);
                }
            }
            catch (DbException exp)
            {
                trans.Rollback();
                throw exp;
            }
            trans.Commit();
            return sum;
        }
        public int Delete(string table, string condition, params DbParameter[] parameters)
        {
            return Delete(table, condition, null, parameters);
        }
        public virtual int Delete(string table, string condition,DbTransaction tran, params DbParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from {0}", table);
            if (!string.IsNullOrEmpty(condition))
            {
                sb.AppendFormat(" where {0}", condition);
            }
            int c = ExecuteNonQuery(sb.ToString(), CommandType.Text, tran, parameters);
            return c;
        }
        public int Update(string table, string set, string condition,params DbParameter[] parameters)
        {
            return Update(table, set, condition, null, parameters);
        }
        public virtual int Update(string table, string set, string condition, DbTransaction tran, params DbParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update {0} set {1}", table, set);
            if (!string.IsNullOrEmpty(condition))
            {
                sb.AppendFormat(" where {0}", condition);
            }
            int c = ExecuteNonQuery(sb.ToString(), CommandType.Text, tran, parameters);
            return c;
        }
        public virtual PageResult SelectPage(string tables, string fields, string condition, string orderby, int pageIndex, int pageSize, bool isTotalCount, params DbParameter[] parameters)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentException("pageIndex参数应>1");
            }
            if (string.IsNullOrEmpty(orderby))
            {
                throw new ArgumentException("orderby参数不能为空或null");
            }
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
            PageResult result = new PageResult();
            StringBuilder sb = new StringBuilder();
            if (isTotalCount)
            {
                sb.AppendFormat("select count(0) from {0}", tables);
                if (!string.IsNullOrEmpty(condition))
                {
                    sb.AppendFormat(" where {0}", condition);
                }
                result.TotalCount = (int)ExecuteScalar(sb.ToString(), CommandType.Text, null, parameters);
                
                if (result.TotalCount == 0) //总数为0了，肯定没有数据
                {
                    return result;
                }
                sb.Clear();
            }
            sb.AppendFormat("select * from (");
            sb.AppendFormat(" select top {0} {1},ROW_NUMBER() over(order by {2}) rowid from {3}", pageIndex * pageSize, fields, orderby, tables);
            if (!string.IsNullOrEmpty(condition))
            {
                sb.AppendFormat(" where {0}", condition);
            }
            sb.AppendFormat(")t where t.rowid>{0}", (pageIndex - 1) * pageSize);
            result.Rows = ExecuteModels(sb.ToString(), CommandType.Text, CopyParameters(parameters));
            return result;
        }
        public virtual PageResult<T> SelectPage<T>(string tables, string fields, string condition, string orderby, int pageIndex, int pageSize, bool isTotalCount, params DbParameter[] parameters)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentException("pageIndex参数应>1");
            }
            if (string.IsNullOrEmpty(orderby))
            {
                throw new ArgumentException("orderby参数不能为空或null");
            }
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
            PageResult<T> result = new PageResult<T>();
            StringBuilder sb = new StringBuilder();
            if (isTotalCount)
            {
                sb.AppendFormat("select count(0) from {0}", tables);
                if (!string.IsNullOrEmpty(condition))
                {
                    sb.AppendFormat(" where {0}", condition);
                }
                result.TotalCount = (int)ExecuteScalar(sb.ToString(), CommandType.Text, null, parameters);
                if (result.TotalCount == 0) //总数为0了，肯定没有数据
                {
                    return result;
                }
                sb.Clear();
            }
            sb.AppendFormat("select * from (");
            sb.AppendFormat(" select top {0} {1},ROW_NUMBER() over(order by {2}) rowid from {3}", pageIndex * pageSize, fields, orderby, tables);
            if (!string.IsNullOrEmpty(condition))
            {
                sb.AppendFormat(" where {0}", condition);
            }
            sb.AppendFormat(")t where t.rowid>{0}", (pageIndex - 1) * pageSize);
            result.Rows = ExecuteModels<T>(sb.ToString(), CommandType.Text, CopyParameters(parameters));
            return result;
        }

        public virtual int GetCount(string table, string condition, params DbParameter[] parameters)
        {
            string sql = "select count(0) from [" + table + "]";
            if (!string.IsNullOrEmpty(condition))
            {
                sql = sql + " where " + condition;
            }
            object obj = ExecuteScalar(sql, CommandType.Text, null, parameters);
            return (int)obj;
        }
        #endregion


        #region 打开关闭
        public void Open()
        {
            if (Conn == null)
            {
                Conn = GetConn();
                Conn.ConnectionString = ConnStr;
            }
            if (Conn.State == System.Data.ConnectionState.Closed)
                Conn.Open();
        }
        public void Close()
        {
            Dispose();
        }
        private bool disposed = false;
        ~DBServer()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposeing)
        {
            if (disposed) return;
            if (disposeing)
            {
                //人工释放，释放托管资源
                
            }
            if (Conn != null && Conn.State != ConnectionState.Closed)
            {
                Conn.Dispose();
                Conn = null;
            }
            disposed = true;
        }
        #endregion
    }
}
