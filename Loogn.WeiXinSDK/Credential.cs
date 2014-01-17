using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            var json = Util.HttpGet2(string.Format(TokenUrl, appId, appSecret));
            cred = Util.JsonTo<Credential>(json);
            return cred;
        }
    }
}
