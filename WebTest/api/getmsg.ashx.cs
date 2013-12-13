using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loogn.Common;

namespace WebTest.api
{
    /// <summary>
    /// getmsg 的摘要说明
    /// </summary>
    public class getmsg : IHttpAsyncHandler
    {

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            int mid = int.Parse(context.Request.QueryString["mid"]);

            if (CometManager.Clients.Keys.Contains(mid))
            {
                CometManager.Clients[mid].Context = context;
                CometManager.Clients[mid].CallBack = cb;
                return CometManager.Clients[mid];
            }
            MyAsyncResult asyncResult = new MyAsyncResult(context, cb, mid);
            CometManager.Clients[mid] = asyncResult;
            return asyncResult;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            MyAsyncResult rslt = (MyAsyncResult)result;
            rslt.Context.Response.Write(SerializerHelper.ToJson(rslt.Msg));
            rslt.Msg.Content = string.Empty;
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public void ProcessRequest(HttpContext context)
        {
            ;
        }
    }
}