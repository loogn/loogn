
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if SQLite
using System.Data.SQLite;
using System.Data.Common;

namespace Loogn.DB
{
    public class SqliteDbServer : DBServer
    {
        public SqliteDbServer(string conn = "", ConnType type = ConnType.ConnName)
            : base(conn, type)
        { }
        public static SqliteDbServer GetInstance(string conn = "", ConnType type = ConnType.ConnName)
        {
            return new SqliteDbServer(conn, type);
        }

        protected override DbConnection GetConn()
        {
            return new SQLiteConnection();
        }

        protected override DbDataAdapter GetAdpt()
        {
            return new SQLiteDataAdapter();
        }

        protected override DbParameter GetParameter()
        {
            return new SQLiteParameter();
        }
    }
}
#endif