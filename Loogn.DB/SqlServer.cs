using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Loogn.DB;
using System.Data;
using System.Data.Common;

namespace Loogn.DB
{
    public class SqlServer : DBServer
    {
        public SqlServer(string conn = "", ConnType type = ConnType.ConnName)
            : base(conn, type)
        { }

        public static SqlServer GetInstance(string conn = "", ConnType type = ConnType.ConnName)
        {
            return new SqlServer(conn, type);
        }

        protected override DbConnection GetConn()
        {
            return new SqlConnection();
        }
        protected override DbDataAdapter GetAdpt()
        {
            return new SqlDataAdapter();
        }
        protected override DbParameter GetParameter()
        {
            return new SqlParameter();
        }
    }
}
