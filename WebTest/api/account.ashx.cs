using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loogn.Common;

namespace WebTest.api
{
    /// <summary>
    /// account 的摘要说明
    /// </summary>
    public class account : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["act"])
            { 
                case "register":
                    Register(context);
                    break;
                case "login":
                    Login(context);
                    break;
                case "getlist":
                    GetList(context);
                    break;
            }
        }

        private void Register(HttpContext context)
        {
            Member m = new Member();
            m.Name = context.Request["name"];
            m.Password = context.Request["password"];
            int flag=DataOpt.Register(m);
            context.Response.Write(flag);
        }
        private void Login(HttpContext context)
        {
            Member mem = new Member();
            mem.Name = context.Request["name"];
            mem.Password = context.Request["password"];
            mem = DataOpt.Login(mem);
            string result = "";
            if (mem == null)
            {
                result = "0";
            }
            else
            {
                result = SerializerHelper.ToJson(mem);
                CometManager.Login(mem);
            }
            context.Response.Write(result);
        }

        private void GetList(HttpContext context)
        {
            context.Response.Write(SerializerHelper.ToJson(CometManager.OnlineMembers.Values));
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}