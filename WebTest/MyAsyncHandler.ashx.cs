using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class MyAsyncHandler : IHttpAsyncHandler
    {
        public static List<MyAsyncResult> Queue = new List<MyAsyncResult>();

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string sessionId = context.Request.QueryString["sessionId"];
            if (Queue.Find(q => q.SessionId == sessionId) != null)
            {
                int index = Queue.IndexOf(Queue.Find(q => q.SessionId == sessionId));
                Queue[index].Context = context;
                Queue[index].CallBack = cb;
                return Queue[index];
            }
            MyAsyncResult asyncResult = new MyAsyncResult(context, cb, sessionId);
            Queue.Add(asyncResult);
            return asyncResult;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            MyAsyncResult rslt = (MyAsyncResult)result;
            rslt.Context.Response.Write(rslt.Message);
            rslt.Message = string.Empty;
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
        }
    }
}