using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data.Common;

namespace Loogn.DB
{
    public class OdbcServer:DBServer
    {
        public OdbcServer(string conn = "", ConnType type = ConnType.ConnName)
            : base(conn, type)
        { }
        public static OdbcServer GetInstance(string conn = "", ConnType type = ConnType.ConnName)
        {
            return new OdbcServer(conn, type);
        }

        protected override DbConnection GetConn()
        {
            return new OdbcConnection();
        }

        protected override DbDataAdapter GetAdpt()
        {
            return new OdbcDataAdapter();
        }

        protected override DbParameter GetParameter()
        {
            return new OdbcParameter();
        }
    }
}
