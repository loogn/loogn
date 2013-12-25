
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Loogn.DB
{
    public class MySqlServer : DBServer
    {
        public MySqlServer(string conn = "", ConnType type = ConnType.ConnName)
            : base(conn, type)
        { }
        public static MySqlServer GetInstance(string conn = "", ConnType type = ConnType.ConnName)
        {
            return new MySqlServer(conn, type);
        }

        protected override DbConnection GetConn()
        {
            
            return new MySqlConnection();
        }

        protected override DbDataAdapter GetAdpt()
        {
            return new MySqlDataAdapter();
        }

        protected override DbParameter GetParameter()
        {
            return new MySqlParameter();
        }
    }
}
