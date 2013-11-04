using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.IO.Compression;

namespace Loogn.Common
{
    public static class WebHelper
    {
        /// <summary>
        /// Http流压缩处理
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public static void HttpCompress(HttpRequest request, HttpResponse response)
        {
            var acceptEncoding = request.Headers["Accept-Encoding"];
            if (string.IsNullOrEmpty(acceptEncoding)) return;
            acceptEncoding = acceptEncoding.ToUpperInvariant();
            if (acceptEncoding.Contains("GZIP"))
            {
                response.AppendHeader("Content-encoding", "gzip");
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
            }
            else if (acceptEncoding.Contains("DEFLATE"))
            {
                response.AppendHeader("Content-encoding", "deflate");
                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
            }
        }

        #region Http请求

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


        /// <summary>
        /// HTTP 的GET、POST请求
        /// </summary>
        /// <param name="action">url</param>
        /// <param name="method">GET 或 Post</param>
        /// <param name="args">如：a=avalue&b=bvalue&c=cvalue</param>
        /// <returns></returns>
        public static Stream HttpRequest(string action, string method, string args)
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
                byte[] data = Encoding.ASCII.GetBytes(args);
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
            return myResponse.GetResponseStream();
        }

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

        #endregion
    }
}
