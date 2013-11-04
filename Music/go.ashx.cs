using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music
{
    /// <summary>
    /// go 的摘要说明
    /// </summary>
    public class go : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Redirect("男人歌.mp3");
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