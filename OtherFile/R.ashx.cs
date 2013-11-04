using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Web.Caching;

    /// <summary>
    /// Provider 的摘要说明
    /// </summary>
public class R : IHttpHandler
{
    public static string Require(params string[] files)
    {
        return Require(true, files);
    }
    public static string Require(bool combine, params string[] files)
    {
        if (files == null || files.Length == 0)
            return string.Empty;

        if (files[0].EndsWith("js", true, null))
        {
            if (combine)
            {
                return "<script type=\"text/javascript\" src=\"/handle/R.ashx?type=js&files=" + string.Join(",", files) + "\"></script>";
            }
            else
            {
                var scriptLink = string.Empty;
                foreach (var js in files)
                {
                    scriptLink += "<script type=\"text/javascript\" src=\"" + js + "\"></script>";
                }
                return scriptLink;
            }
        }
        else
        {
            if (combine)
            {
                return "<link rel=\"stylesheet\" type=\"text/css\" href=\"/handle/R.ashx?type=css&files=" + string.Join(",", files) + "\"/>";
            }
            {
                var cssLink = string.Empty;
                foreach (var css in files)
                {
                    cssLink += "<link rel=\"stylesheet\" type=\"text/css\" href=\"" + css + "\"/>";
                }
                return cssLink;
            }
        }
    }

    private const bool DO_GZIP = true;
    private readonly static TimeSpan CACHE_DURATION = TimeSpan.FromDays(30);

    public void ProcessRequest(HttpContext context)
    {
        var type = context.Request.QueryString["type"];
        var strFiles = context.Request.QueryString["files"];
        if (type == "js")
            context.Response.ContentType = "application/x-javascript";
        else if (type == "css")
            context.Response.ContentType = "text/css";
        else
            return;
        if (string.IsNullOrEmpty(strFiles))
            return;

        bool isCompressed = DO_GZIP && CanGZip(context.Request);

        UTF8Encoding encoding = new UTF8Encoding(false);

        if (!WriteFromCache(context, strFiles, isCompressed))
        {
            System.Collections.Generic.List<string> dependencyFiles = new System.Collections.Generic.List<string>();
            using (MemoryStream memoryStream = new MemoryStream(5000))
            {
                using (Stream writer = isCompressed ?
                    (Stream)(new GZipStream(memoryStream, CompressionMode.Compress)) :
                    memoryStream)
                {
                    string[] fileNames = strFiles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string fileName in fileNames)
                    {
                        byte[] fileBytes = GetFileBytes(type, context, fileName.Trim(), encoding, dependencyFiles);
                        writer.Write(fileBytes, 0, fileBytes.Length);
                    }
                    writer.Close();
                }
                byte[] responseBytes = memoryStream.ToArray();
                context.Cache.Insert(GetCacheKey(strFiles, isCompressed), responseBytes, new CacheDependency(dependencyFiles.ToArray()), System.Web.Caching.Cache.NoAbsoluteExpiration, CACHE_DURATION);
                WriteBytes(responseBytes, context, isCompressed);
            }
        }
    }


    private static byte[] GetFileBytes(string type, HttpContext context, string virtualPath, Encoding encoding, System.Collections.Generic.List<string> depencesFile)
    {
        if (virtualPath.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(virtualPath);
            }
        }
        else
        {
            string physicalPath = context.Server.MapPath("~" + virtualPath);
            depencesFile.Add(physicalPath);
            byte[] bytes = File.ReadAllBytes(physicalPath);
            return bytes;
        }
    }

    private static bool WriteFromCache(HttpContext context, string setName, bool isCompressed)
    {
        byte[] responseBytes = context.Cache[GetCacheKey(setName, isCompressed)] as byte[];
        if (null == responseBytes || 0 == responseBytes.Length) return false;
        WriteBytes(responseBytes, context, isCompressed);
        return true;
    }

    private static void WriteBytes(byte[] bytes, HttpContext context, bool isCompressed)
    {
        HttpResponse response = context.Response;
        response.AppendHeader("Content-Length", bytes.Length.ToString());
        if (isCompressed) response.AppendHeader("Content-Encoding", "gzip");
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.Cache.SetExpires(DateTime.Now.Add(CACHE_DURATION));
        context.Response.Cache.SetMaxAge(CACHE_DURATION);
        context.Response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
        response.OutputStream.Write(bytes, 0, bytes.Length);
        response.Flush();
    }

    private static bool CanGZip(HttpRequest request)
    {
        string acceptEncoding = request.Headers["Accept-Encoding"];
        if (!string.IsNullOrEmpty(acceptEncoding) && (acceptEncoding.Contains("gzip") || acceptEncoding.Contains("deflate")))
            return true;
        return false;
    }

    private static string GetCacheKey(string setName, bool isCompressed)
    {
        return "HttpCombiner." + setName + "." + isCompressed;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
