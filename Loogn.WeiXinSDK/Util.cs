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
        public static Stream HttpRequest(string action, byte[] data)
        {
            HttpWebRequest myRequest;
            myRequest = WebRequest.Create(action) as HttpWebRequest;
            myRequest.Method = "POST";
            myRequest.ContentType = "multipart/form-data";
            myRequest.ContentLength = data.Length;
            using (Stream newStream = myRequest.GetRequestStream())
            {
                newStream.Write(data, 0, data.Length);
            }
            HttpWebResponse myResponse = myRequest.GetResponse() as HttpWebResponse;
            return myResponse.GetResponseStream();
        }
        /// <summary>
        /// 模拟GET、POST提交
        /// </summary>
        /// <param name="action">url</param>
        /// <param name="method">get or post</param>
        /// <param name="args">params，如a=avalue&b=bvalue&c=cvalue</param>
        /// <param name="encoding">encoding</param>
        /// <returns></returns>
        public static string HttpRequest(string action, string method, string args, Encoding encoding)
        {
            string m = method.ToUpper();
            HttpWebRequest myRequest;
            if (m == "GET")
            {
                if (!string.IsNullOrEmpty(args))
                {
                    action = action + "?" + args;
                }
                myRequest = WebRequest.Create(action) as HttpWebRequest;
                myRequest.Method = m;
            }
            else if (m == "POST")
            {
                myRequest = WebRequest.Create(action) as HttpWebRequest;
                myRequest.Method = m;
                byte[] data = encoding.GetBytes(args);
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                using (Stream newStream = myRequest.GetRequestStream())
                {
                    newStream.Write(data, 0, data.Length);
                }
            }
            else
            {
                throw new Exception("method参数必需是GET或POST");
            }
            HttpWebResponse myResponse = myRequest.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), encoding);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
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
