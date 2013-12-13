using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.api
{
    /// <summary>
    /// setmsg 的摘要说明
    /// </summary>
    public class setmsg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Message msg = new Message();
            msg.ToID = int.Parse(context.Request["toid"] ?? "0");
            msg.FromID = int.Parse(context.Request["fromid"] ?? "0");
            msg.Content = context.Request["content"] ?? string.Empty;
            msg.FromUser = context.Request["fromuser"] ?? string.Empty;

            MyAsyncResult client;
            if (CometManager.Clients.TryGetValue(msg.ToID, out client))
            {
                client.Msg = msg;
                client.SetCompleted(true);
            }
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