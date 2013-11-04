using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.Common;

namespace Loogn.DB
{
    public class OleDbServer : DBServer
    {
        public OleDbServer(string conn="", ConnType type= ConnType.ConnName)
            : base(conn, type)
        { }
        public static OleDbServer GetInstance(string conn = "", ConnType type = ConnType.ConnName)
        {
            return new OleDbServer(conn, type);
        }

        protected override DbConnection GetConn()
        {
            return new OleDbConnection();
        }

        protected override DbDataAdapter GetAdpt()
        {
            return new OleDbDataAdapter();
        }

        protected override DbParameter GetParameter()
        {
            return new OleDbParameter();
        }
    }
}
