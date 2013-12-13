using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest
{
    public class CometManager
    {
        public static Dictionary<int, Member> OnlineMembers = new Dictionary<int, Member>();
        
        public static Dictionary<int, MyAsyncResult> Clients = new Dictionary<int, MyAsyncResult>();
     
        public static void Login(Member mem)
        {
            OnlineMembers[mem.ID] = mem;
        }

        public static bool IsLogin(int id)
        {
            return OnlineMembers.Keys.Contains(id);
        }
    }
}