using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest
{
    public class MyAsyncResult:IAsyncResult
    {
        public object AsyncState
        {
            get;
            private set;
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get;
            private set;
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted
        {
            get;
            private set;
        }

        //=======================
        public HttpContext Context { get; set; }
        public AsyncCallback CallBack { get; set; }
        public string SessionId { get; set; }
        public string Message { get; set; }

        public MyAsyncResult(HttpContext context, AsyncCallback cb, string sessionId)
        {
            this.SessionId = sessionId;
            this.Context = context;
            this.CallBack = cb;
        }

        public void SetCompleted(bool iscompleted)
        {
            this.IsCompleted = iscompleted;
            if (iscompleted && this.CallBack != null)
            {
                CallBack(this);
            }
        }
    }
}