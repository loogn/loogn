using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loogn.DB;

namespace WebTest
{
    public static class DataOpt
    {
        public static int Register(Member mem)
        {
            using (var db = DBServer.GetSqlServer())
            {
                return db.Insert("Member", new { mem.Name, mem.Password });
            }
        }

        public static Member Login(Member m)
        {
            using (var db = DBServer.GetSqlServer())
            {
                return db.SelectOne<Member>("Member", "ID,Name", "Name=@n and Password=@p",
                    db.CreateParameter("@n", m.Name), db.CreateParameter("@p", m.Password));
            }
        }

    }
}