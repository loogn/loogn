using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Loogn.WeiXinSDK.Message;

namespace Loogn.WeiXinSDK
{
    public class WeiXin
    {
        static string SendUrl = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=";


        public static string GetAccessToken(string appId, string appSecret)
        {
            return Credential.GetCredential(appId, appSecret).access_token;
        }

        /// <summary>
        /// 检验signature
        /// </summary>
        /// <param name="signature">微信加密签名</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="token">由AppId和AppSecret得到的凭据</param>
        /// <returns></returns>
        public static bool CheckSignature(string signature, string timestamp, string nonce, string token)
        {
            List<string> tmpList = new List<string>(3);
            tmpList.Add(token);
            tmpList.Add(timestamp);
            tmpList.Add(nonce);
            tmpList.Sort();
            var tmpStr = string.Join("", tmpList.ToArray());
            string strResult = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            return signature.Equals(strResult, StringComparison.InvariantCultureIgnoreCase);
        }

        public static ReplyBaseMsg DealRecMsg(Stream inputStream, Func<RecEventBase, ReplyBaseMsg> hander)
        {
            try
            {
                byte[] buffer = new byte[inputStream.Length];
                inputStream.Read(buffer, 0, buffer.Length);
                string xml = System.Text.Encoding.UTF8.GetString(buffer);
                var dict = Util.GetDictFromXml(xml);
                RecEventBase recEvMsg = null;
                if (dict.ContainsKey("Event"))
                {
                    #region 接收事件消息

                    EventBaseMsg evMsg = null;
                    var evt = (EventType)Enum.Parse(typeof(EventType), dict["Event"]);

                    switch (evt)
                    {
                        case EventType.CLICK:
                            {
                                evMsg = new EventClickMsg { MyEventType = MyEventType.Click, EventKey = dict["EventKey"] };
                                break;
                            }
                        case EventType.LOCATION:
                            {
                                evMsg = new EventLocationMsg { MyEventType = MyEventType.Location, Latitude = double.Parse(dict["Latitude"]), Longitude = double.Parse(dict["Longitude"]), Precision = double.Parse(dict["Precision"]) };
                                break;
                            }
                        case EventType.scan:
                            {
                                evMsg = new EventFansScanMsg { MyEventType = MyEventType.FansScan, EventKey = dict["EventKey"], Ticket = dict["Ticket"] };
                                break;
                            }
                        case EventType.unsubscribe:
                            {
                                evMsg = new EventUnattendMsg { MyEventType = MyEventType.Unattend };
                                break;
                            }
                        case EventType.subscribe:
                            {
                                if (dict.ContainsKey("Ticket"))
                                {
                                    evMsg = new EventUserScanMsg { MyEventType = MyEventType.UserScan, Ticket = dict["Ticket"], EventKey = dict["EventKey"] };
                                }
                                else
                                {
                                    evMsg = new EventAttendMsg { MyEventType = MyEventType.Attend };
                                }
                                break;
                            }
                        default:
                            return ReplyEmptyMsg.Instance;
                    }
                    #endregion
                }
                else if (dict.ContainsKey("MsgId"))
                {
                    #region 接收普通消息
                    RecBaseMsg recMsg = null;
                    switch (dict["MsgType"])
                    {
                        case "text":
                            {
                                recMsg = new RecTextMsg { Content = dict["Content"] };
                                break;
                            }
                        case "image":
                            {

                                recMsg = new RecImageMsg { PicUrl = dict["PicUrl"], MediaId = dict["MediaId"] };
                                break;
                            }
                        case "voice":
                            {
                                recMsg = new RecVoiceMsg { Format = dict["Format"], MediaId = dict["MediaId"] };
                                break;
                            }
                        case "video":
                            {
                                recMsg = new RecVideoMsg { ThumbMediaId = dict["ThumbMediaId"], MediaId = dict["MediaId"] };
                                break;
                            }
                        case "location":
                            {
                                recMsg = new RecLocationMsg { Label = dict["Label"], Location_X = double.Parse(dict["Location_X"]), Location_Y = double.Parse(dict["Location_Y"]), Scale = int.Parse(dict["Scale"]) };
                                break;
                            }
                        case "link":
                            {
                                recMsg = new RecLinkMsg { Description = dict["Description"], Title = dict["Title"], Url = dict["Url"] };
                                break;
                            }
                        default:
                            return ReplyEmptyMsg.Instance;
                    }
                    recMsg.MsgId = Int64.Parse(dict["MsgId"]);
                    recEvMsg = recMsg;
                    #endregion
                }
                else
                {
                    return ReplyEmptyMsg.Instance;
                }
                recEvMsg.CreateTime = Int64.Parse(dict["CreateTime"]);
                recEvMsg.FromUserName = dict["FromUserName"];
                recEvMsg.ToUserName = dict["ToUserName"];

                return hander(recEvMsg);
            }
            catch
            {
                return ReplyEmptyMsg.Instance;
            }
        }

    }
}
