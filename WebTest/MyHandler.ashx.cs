using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest
{
    /// <summary>
    /// MyHandler 的摘要说明
    /// </summary>
    public class MyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            List<MyAsyncResult> userList = MyAsyncHandler.Queue;
            string sessionId = context.Request["sessionId"];
            string message = context.Request["message"];
            foreach (var res in userList)
            {
                if (res.SessionId != sessionId)
                {
                    res.Message = message;
                    res.SetCompleted(true);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}