﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Loogn.WeiXinSDK.Message;
using Loogn.WeiXinSDK.Menu;

namespace Loogn.WeiXinSDK
{
    public class WeiXin
    {
        static string AppID, AppSecret;
        /// <summary>
        /// 设置全局appId和appSecret,一般只用在应用程序启动时调用一次即可
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        public static void SetGlobalCredential(string appId, string appSecret)
        {
            AppID = appId;
            AppSecret = appSecret;
        }

        /// <summary>
        /// 得到AccessToken
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
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

        #region 消息

        /// <summary>
        /// 处理用户消息和事件
        /// </summary>
        /// <param name="hander"></param>
        /// <returns></returns>
        public static ReplyBaseMsg DealMsg(Func<RecEventBaseMsg, ReplyBaseMsg> hander)
        {
            try
            {
                Stream inputStream = System.Web.HttpContext.Current.Request.InputStream;
                long pos = inputStream.Position;
                inputStream.Position = 0;
                byte[] buffer = new byte[inputStream.Length];
                inputStream.Read(buffer, 0, buffer.Length);
                inputStream.Position = pos;
                string xml = System.Text.Encoding.UTF8.GetString(buffer);
                var dict = Util.GetDictFromXml(xml);
                RecEventBaseMsg recEvMsg = null;
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
                                string recognition;
                                dict.TryGetValue("Recognition", out recognition);
                                recMsg = new RecVoiceMsg { Format = dict["Format"], MediaId = dict["MediaId"], Recognition = recognition };
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

        /// <summary>
        /// 主动给用户发消息（用户）
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns>errcode=0为成功</returns>
        public static ReturnCode SendMsg(SendBaseMsg msg, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = msg.GetJSON();

            var retJson = Util.HttpPost2(url, json);
            return ReturnCode.JsonTo(retJson);
        }

        /// <summary>
        /// 主动给用户发消息（用户）,用会SetGlobalCredential方法设置的appId和appSecret来得到access_token
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ReturnCode SendMsg(SendBaseMsg msg)
        {
            CheckGlobalCredential();
            return SendMsg(msg, AppID, AppSecret);
        }

        #endregion

        #region 自定义菜单

        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode CreateMenu(CustomMenu menu, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = menu.GetJSON();
            var retJson = Util.HttpPost2(url, json);
            return ReturnCode.JsonTo(retJson);
        }

        public static ReturnCode CreateMenu(CustomMenu menu)
        {
            CheckGlobalCredential();
            return CreateMenu(menu, AppID, AppSecret);
        }

        /// <summary>
        /// 直接返回自定义菜单json字符串，
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static string GetMenu(string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpGet2(url);
            return json;
        }

        public static string GetMenu()
        {
            CheckGlobalCredential();
            return GetMenu(AppID, AppSecret);
        }

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode DeleteMenu(string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpGet2(url);
            return ReturnCode.JsonTo(json);
        }

        public static ReturnCode DeleteMenu()
        {
            CheckGlobalCredential();
            return DeleteMenu(AppID, AppSecret);
        }

        #endregion

        #region 二维码

        /// <summary>
        /// 创建二维码ticket
        /// </summary>
        /// <param name="isTemp"></param>
        /// <param name="scene_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static QRCodeTicket CreateQRCode(bool isTemp, int scene_id, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var action_name = isTemp ? "QR_SCENE" : "QR_LIMIT_SCENE";
            string data;
            if (isTemp)
            {
                data = "{\"expire_seconds\": 1800, \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\":" + scene_id + "}}}";
            }
            else
            {
                data = "{\"action_name\": \"QR_LIMIT_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + scene_id + "}}}";
            }

            var json = Util.HttpPost2(url, data);
            if (json.IndexOf("ticket") > 0)
            {
                return Util.JsonTo<QRCodeTicket>(json);
            }
            else
            {
                QRCodeTicket tk = new QRCodeTicket();
                tk.error = Util.JsonTo<ReturnCode>(json);
                return tk;
            }
        }

        public static QRCodeTicket CreateQRCode(bool isTemp, int scene_id)
        {
            CheckGlobalCredential();
            return CreateQRCode(isTemp, scene_id, AppID, AppSecret);
        }

        public static string GetQRUrl(string qrcodeTicket)
        {
            return "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + System.Web.HttpUtility.HtmlEncode(qrcodeTicket);
        }

        #endregion

        #region 获取关注者列表

        /// <summary>
        /// 获取关注者列表
        /// </summary>
        /// <param name="next_openid"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static Followers GetFollowers(string next_openid, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/user/get?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            if (!string.IsNullOrEmpty(next_openid))
            {
                url = url + "&next_openid=" + next_openid;
            }
            var json = Util.HttpGet2(url);
            if (json.IndexOf("errcode") > 0)
            {
                var fs = new Followers();
                fs.error = Util.JsonTo<ReturnCode>(json);
                return fs;
            }
            else
            {
                return Util.JsonTo<Followers>(json);
            }
        }

        public static Followers GetFollowers(string next_openid)
        {
            CheckGlobalCredential();
            return GetFollowers(next_openid, AppID, AppSecret);
        }

        /// <summary>
        /// 获取所有关注者列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static Followers GetAllFollowers(string appId, string appSecret)
        {
            Followers allFollower = new Followers();
            allFollower.data = new Followers.Data();
            allFollower.data.openid = new List<string>();

            string next_openid = string.Empty;
            do
            {
                var f = GetFollowers(next_openid, appId, appSecret);
                if (f.error != null)
                {
                    allFollower.error = f.error;
                    break;
                }
                else
                {
                    if (f.count > 0)
                    {
                        foreach (var opid in f.data.openid)
                        {
                            allFollower.data.openid.Add(opid);
                        }
                    }
                    next_openid = f.next_openid;
                }
            } while (!string.IsNullOrEmpty(next_openid));

            allFollower.count = allFollower.total;
            return allFollower;
        }

        public static Followers GetAllFollowers()
        {
            CheckGlobalCredential();
            return GetAllFollowers(AppID, AppSecret);
        }

        #endregion

        #region 用户信息
        /// <summary>
        /// 得到用户基本信息
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="lang"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfo(string openid, LangType lang, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token + "&openid=" + openid + "&lang=" + lang.ToString();

            var json = Util.HttpGet2(url);

            if (json.IndexOf("errcode") > 0)
            {
                var ui = new UserInfo();
                ui.error = Util.JsonTo<ReturnCode>(json);
                return ui;
            }
            else
            {
                return Util.JsonTo<UserInfo>(json);
            }
        }

        public static UserInfo GetUserInfo(string openid, LangType lang)
        {
            CheckGlobalCredential();
            return GetUserInfo(openid, lang, AppID, AppSecret);
        }

        #endregion

        #region 分组

        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="name">分组名字（30个字符以内）</param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GroupInfo CreateGroup(string name, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/create?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var post = "{\"group\":{\"name\":\"" + name + "\"}}";
            var json = Util.HttpPost2(url, post);
            if (json.IndexOf("errcode") > 0)
            {
                var gi = new GroupInfo();
                gi.error = Util.JsonTo<ReturnCode>(json);
                return gi;
            }
            else
            {
                var dict = Util.JsonTo<Dictionary<string, Dictionary<string, object>>>(json);
                var gi = new GroupInfo();
                var gpdict = dict["group"];
                gi.id = Convert.ToInt32(gpdict["id"]);
                gi.name = gpdict["name"].ToString();
                return gi;
            }
        }

        public static GroupInfo CreateGroup(string name)
        {
            CheckGlobalCredential();
            return CreateGroup(name, AppID, AppSecret);
        }

        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static Groups GetGroups(string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/get?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            string json = Util.HttpGet2(url);
            if (json.IndexOf("errcode") > 0)
            {
                var gs = new Groups();
                gs.error = Util.JsonTo<ReturnCode>(json);
                return gs;
            }
            else
            {
                var dict = Util.JsonTo<Dictionary<string, List<Dictionary<string, object>>>>(json);
                var gs = new Groups();
                var gilist = dict["groups"];
                foreach (var gidict in gilist)
                {
                    var gi = new GroupInfo();
                    gi.name = gidict["name"].ToString();
                    gi.id = Convert.ToInt32(gidict["id"]);
                    gi.count = Convert.ToInt32(gidict["count"]);
                    gs.Add(gi);
                }
                return gs;
            }
        }

        public static Groups GetGroups()
        {
            CheckGlobalCredential();
            return GetGroups(AppID, AppSecret);
        }

        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GroupID GetUserGroup(string openid, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var post = "{\"openid\":\"" + openid + "\"}";
            var json = Util.HttpPost2(url, post);
            if (json.IndexOf("errcode") > 0)
            {
                var gid = new GroupID();
                gid.error = Util.JsonTo<ReturnCode>(json);
                return gid;
            }
            else
            {
                var dict = Util.JsonTo<Dictionary<string, int>>(json);
                var gid = new GroupID();
                gid.id = dict["groupid"];
                return gid;
            }
        }

        public static GroupID GetUserGroup(string openid)
        {
            CheckGlobalCredential();
            return GetUserGroup(openid, AppID, AppSecret);
        }

        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode UpdateGroup(int id, string name, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/update?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var post = "{\"group\":{\"id\":" + id + ",\"name\":\"" + name + "\"}}";
            var json = Util.HttpPost2(url, post);
            return Util.JsonTo<ReturnCode>(json);
        }

        public static ReturnCode UpdateGroup(int id, string name)
        {
            CheckGlobalCredential();
            return UpdateGroup(id, name, AppID, AppSecret);
        }
        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="groupid"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode MoveGroup(string openid, int groupid, string appId, string appSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token;
            var post = "{\"openid\":\"" + openid + "\",\"to_groupid\":" + groupid + "}";
            var json = Util.HttpPost2(url, post);
            return Util.JsonTo<ReturnCode>(json);
        }

        #endregion

        #region 多媒体文件
        /// <summary>
        /// 上传多媒体文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static MediaInfo UploadMedia(string file, MediaType type, string appId, string appSecret)
        {
            string url = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token + "&type=" + type.ToString();
            var json = Util.HttpUpload(url, file);
            if (json.IndexOf("errcode") > 0)
            {
                var mi = new MediaInfo();
                mi.error = Util.JsonTo<ReturnCode>(json);
                return mi;
            }
            else
            {
                return Util.JsonTo<MediaInfo>(json);
            }
        }

        public static MediaInfo UploadMedia(string file, MediaType type)
        {
            CheckGlobalCredential();
            return UploadMedia(file, type, AppID, AppSecret);
        }

        /// <summary>
        /// 下载多媒体文件
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static DownloadFile DownloadMedia(string media_id, string appId, string appSecret)
        {
            string url = "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token=";
            string access_token = GetAccessToken(appId, appSecret);
            url = url + access_token + "&media_id=" + media_id;
            var tup = Util.HttpGet(url);
            var dm = new DownloadFile();
            dm.ContentType = tup.Item2;
            
            if (tup.Item1 == null)
            {
                dm.error = Util.JsonTo<ReturnCode>(tup.Item3);
            }
            else
            {
                dm.Stream = tup.Item1;
            }
            return dm;
        }

        public static DownloadFile DownloadMedia(string media_id)
        {
            CheckGlobalCredential();
            return DownloadMedia(media_id, AppID, AppSecret);
        }

        #endregion

        #region 授权获取用户基本信息 ????????????
        #endregion

        private static void CheckGlobalCredential()
        {
            if (string.IsNullOrEmpty(AppID) || string.IsNullOrEmpty(AppSecret))
            {
                throw new ArgumentNullException("全局AppID,AppSecret", "请先调用SetGlobalCredential");
            }
        }
    }
}