using System.Web;
using Loogn.WeiXinSDK;
using Loogn.WeiXinSDK.Message;

namespace WebTest
{
    /// <summary>
    /// 微信->服务器配置URL
    /// </summary>
    public class WeiXinAPI : IHttpHandler
    {
        static string Token = "Token";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var signature = context.Request["signature"];
            var timestamp = context.Request["timestamp"];
            var nonce = context.Request["nonce"];
            if (WeiXin.CheckSignature(signature, timestamp, nonce, Token))
            {
                var replyMsg = WeiXin.ReplyMsg();
                var xml = replyMsg.GetXML();
                context.Response.Write(xml);
            }
            else
            {
                context.Response.Write("fuck you!");
            }
        }
        static WeiXinAPI()
        {
            WeiXin.ConfigGlobalCredential("appid", "appSecret");
            WeiXin.RegisterMsgHandler<RecTextMsg>((msg) =>
            {
                return new ReplyTextMsg
                {
                    Content = "你说：" + msg.Content
                };
            });
            WeiXin.RegisterEventHandler<EventAttendMsg>((msg) =>
            {
                return new ReplyTextMsg
                {
                    Content = "Hello !"
                };
            });
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