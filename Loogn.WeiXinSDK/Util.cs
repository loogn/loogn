using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;

namespace Loogn.WeiXinSDK
{
    class Util
    {
        public static Stream HttpPost(string action, byte[] data,bool multi)
        {
            HttpWebRequest myRequest;
            myRequest = WebRequest.Create(action) as HttpWebRequest;
            myRequest.Method = "POST";
            myRequest.ContentType = multi?"multipart/form-data": "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            using (Stream newStream = myRequest.GetRequestStream())
            {
                newStream.Write(data, 0, data.Length);
            }
            HttpWebResponse myResponse = myRequest.GetResponse() as HttpWebResponse;
            return myResponse.GetResponseStream();
        }

        public static Stream HttpPost(string action, byte[] data)
        {
            return HttpPost(action, data, false);
        }
        public static string HttpPost2(string action, string data)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            using (var stream = Util.HttpPost(action, buffer))
            {
                StreamReader sr = new StreamReader(stream);
                data = sr.ReadToEnd();
                return data;
            }
        }

        public static Stream HttpGet(string action)
        {
            HttpWebRequest myRequest = WebRequest.Create(action) as HttpWebRequest;
            myRequest.Method = "GET";
            HttpWebResponse myResponse = myRequest.GetResponse() as HttpWebResponse;
            return myResponse.GetResponseStream();
        }
        public static string HttpGet2(string action)
        {
            using (var stream = Util.HttpGet(action))
            {
                StreamReader sr = new StreamReader(stream);
                var data = sr.ReadToEnd();
                return data;
            }
        }

        #region json
        static JavaScriptSerializer GetJSS()
        {
            return new JavaScriptSerializer();
        }
        public static string ToJson(object obj)
        {
            var jss = GetJSS();
            return jss.Serialize(obj);
        }
        public static void ToJson(object obj, StringBuilder output)
        {
            var jss = GetJSS();
            jss.Serialize(obj, output);
        }

        public static T JsonTo<T>(string json)
        {
            var jss = GetJSS();
            T obj = jss.Deserialize<T>(json);
            return obj;
        }
        public static object JsonTo(string json, Type targetType)
        {
            var jss = GetJSS();
            var obj = jss.DeserializeObject(json);
            return obj;
        }

        public static Dictionary<string, string> GetDictFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                dict.Add(node.Name, node.InnerText.Trim());
            }
            return dict;
        }


        #endregion
    }
}
