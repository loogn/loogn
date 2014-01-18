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
        static string Token = "Token";//这里是Token不是Access_Token
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var signature = context.Request["signature"];
            var timestamp = context.Request["timestamp"];
            var nonce = context.Request["nonce"];
            if (WeiXin.CheckSignature(signature, timestamp, nonce, Token))//验证是微信给你发的消息
            {
                //根据注册的消息、事件处理程序回复，
                //如果得到没用注册的消息或事件，会返回ReplyEmptyMsg.Instance,即GetXML()为string.Empty,符合微信的要求
                var replyMsg = WeiXin.ReplyMsg();
                var xml = replyMsg.GetXML();
                //WriteLog(xml); //这里可以查看回复的XML消息
                context.Response.Write(xml);
            }
            else
            {
                context.Response.Write("fuck you!");
            }
        }
        static WeiXinAPI()
        {
            WeiXin.SetGlobalCredential("appid", "appSecret");
            //注册一个消息处理程序，当用户发"ABC"，你回复“你说：ABC”;
            WeiXin.RegisterMsgHandler<RecTextMsg>((msg) =>
            {
                return new ReplyTextMsg
                {
                    Content = "你说：" + msg.Content
                    //FromUserName = msg.ToUserName,  默认就是这样，不用设置！
                    //ToUserName = msg.FromUserName,  默认就是这样，不用设置！
                    //CreateTime = DateTime.Now.Ticks     默认就是这样，不用设置！
                };
            });
            //注册一个用户关注的事件处理程序，当用户关注你的公众账号时，你回复“Hello!”
            WeiXin.RegisterEventHandler<EventAttendMsg>((msg) =>
            {
                return new ReplyTextMsg
                {
                    Content = "Hello !"
                };
            });
            //还可以继续注册你感兴趣的消息、事件处理程序
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