
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SQLite;
using System.Data.Common;

namespace Loogn.DB
{
    public class SqliteServer : DBServer
    {
        public SqliteServer(string conn = "", ConnType type = ConnType.ConnName)
            : base(conn, type)
        { }
        public static SqliteServer GetInstance(string conn = "", ConnType type = ConnType.ConnName)
        {
            return new SqliteServer(conn, type);
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
