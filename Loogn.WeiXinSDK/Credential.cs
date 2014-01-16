using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.WeiXinSDK
{
    /// <summary>
    /// 凭据
    /// </summary>
    [Serializable]
    class Credential
    {
        public string access_token { get; set; }
        /// <summary>
        /// 过期秒数
        /// </summary>
        public int expires_in { get; set; }

        [NonSerialized]
        public DateTime add_time;

        static Dictionary<string, Credential> creds = new Dictionary<string, Credential>();
        static string TokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        internal static Credential GetCredential(string appId, string appSecret)
        {
            Credential cred = null;
            if (creds.TryGetValue(appId, out cred))
            {
                if (cred.add_time.AddSeconds(cred.expires_in - 30) < DateTime.Now)
                {
                    creds.Remove(appId);
                    cred = null;
                }
                else
                {
                    return cred;
                }
            }
            string json = Util.HttpRequest(string.Format(TokenUrl, appId, appSecret), "GET", string.Empty, Encoding.Default);
            cred = Util.JsonTo<Credential>(json);
            cred.add_time = DateTime.Now;
            creds[appId] = cred;
            return cred;
        }
    }
}
