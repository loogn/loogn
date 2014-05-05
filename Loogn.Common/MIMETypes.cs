using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.Common
{
    public static class MIMETypeHelper
    {
        static Dictionary<string, string> dict_types;
        static Dictionary<string, string> Types
        {
            get
            {
                #region 填充字典
                if (dict_types == null)
                {
                    dict_types = new Dictionary<string, string>();
                    dict_types.Add("html", "text/html");
                    dict_types.Add("htm", "text/html");
                    dict_types.Add("shtml", "text/html");
                    dict_types.Add("css", "text/css");
                    dict_types.Add("xml", "text/xml");
                    dict_types.Add("gif", "image/gif");
                    dict_types.Add("jpeg", "image/jpeg");
                    dict_types.Add("jpg", "image/jpeg");
                    dict_types.Add("jpe", "image/jpeg");
                    dict_types.Add("js", "application/javascript");
                    dict_types.Add("atom", "application/atom+xml");
                    dict_types.Add("rss", "application/rss+xml");
                    dict_types.Add("mml", "text/mathml");
                    dict_types.Add("txt", "text/plain");
                    dict_types.Add("jad", "text/vnd.sun.j2me.app-descriptor");
                    dict_types.Add("wml", "text/vnd.wap.wml");
                    dict_types.Add("htc", "text/x-component");
                    dict_types.Add("png", "image/png");
                    dict_types.Add("tif", "image/tiff");
                    dict_types.Add("tiff", "image/tiff");
                    dict_types.Add("wbmp", "image/vnd.wap.wbmp");
                    dict_types.Add("ico", "image/x-icon");
                    dict_types.Add("jng", "image/x-jng");
                    dict_types.Add("bmp", "image/x-ms-bmp");
                    dict_types.Add("svg", "image/svg+xml");
                    dict_types.Add("svgz", "image/svg+xml");
                    dict_types.Add("webp", "image/webp");
                    dict_types.Add("woff", "application/font-woff");
                    dict_types.Add("jar", "application/java-archive");
                    dict_types.Add("war", "application/java-archive");
                    dict_types.Add("ear", "application/java-archive");
                    dict_types.Add("json", "application/json");
                    dict_types.Add("hqx", "application/mac-binhex40");
                    dict_types.Add("doc", "application/msword");
                    dict_types.Add("pdf", "application/pdf");
                    dict_types.Add("ps", "application/postscript");
                    dict_types.Add("eps", "application/postscript");
                    dict_types.Add("ai", "application/postscript");
                    dict_types.Add("rtf", "application/rtf");
                    dict_types.Add("m3u8", "application/vnd.apple.mpegurl");
                    dict_types.Add("xls", "application/vnd.ms-excel");
                    dict_types.Add("eot", "application/vnd.ms-fontobject");
                    dict_types.Add("ppt", "application/vnd.ms-powerpoint");
                    dict_types.Add("wmlc", "application/vnd.wap.wmlc");
                    dict_types.Add("kml", "application/vnd.google-earth.kml+xml");
                    dict_types.Add("kmz", "application/vnd.google-earth.kmz");
                    dict_types.Add("7z", "application/x-7z-compressed");
                    dict_types.Add("cco", "application/x-cocoa");
                    dict_types.Add("jardiff", "application/x-java-archive-diff");
                    dict_types.Add("jnlp", "application/x-java-jnlp-file");
                    dict_types.Add("run", "application/x-makeself");
                    dict_types.Add("pl", "application/x-perl");
                    dict_types.Add("pm", "application/x-perl");
                    dict_types.Add("prc", "application/x-pilot");
                    dict_types.Add("pdb", "application/x-pilot");
                    dict_types.Add("rar", "application/x-rar-compressed");
                    dict_types.Add("rpm", "application/x-redhat-package-manager");
                    dict_types.Add("sea", "application/x-sea");
                    dict_types.Add("swf", "application/x-shockwave-flash");
                    dict_types.Add("sit", "application/x-stuffit");
                    dict_types.Add("tcl", "application/x-tcl");
                    dict_types.Add("tk", "application/x-tcl");
                    dict_types.Add("der", "application/x-x509-ca-cert");
                    dict_types.Add("pem", "application/x-x509-ca-cert");
                    dict_types.Add("crt", "application/x-x509-ca-cert");
                    dict_types.Add("xpi", "application/x-xpinstall");
                    dict_types.Add("xhtml", "application/xhtml+xml");
                    dict_types.Add("xspf", "application/xspf+xml");
                    dict_types.Add("zip", "application/zip");
                    dict_types.Add("bin", "application/octet-stream");
                    dict_types.Add("exe", "application/octet-stream");
                    dict_types.Add("dll", "application/octet-stream");
                    dict_types.Add("deb", "application/octet-stream");
                    dict_types.Add("dmg", "application/octet-stream");
                    dict_types.Add("iso", "application/octet-stream");
                    dict_types.Add("img", "application/octet-stream");
                    dict_types.Add("msi", "application/octet-stream");
                    dict_types.Add("msp", "application/octet-stream");
                    dict_types.Add("msm", "application/octet-stream");
                    dict_types.Add("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                    dict_types.Add("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    dict_types.Add("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
                    dict_types.Add("mid", "audio/midi");
                    dict_types.Add("midi", "audio/midi");
                    dict_types.Add("kar", "audio/midi");
                    dict_types.Add("mp3", "audio/mpeg");
                    dict_types.Add("ogg", "audio/ogg");
                    dict_types.Add("m4a", "audio/x-m4a");
                    dict_types.Add("ra", "audio/x-realaudio");
                    dict_types.Add("3gpp", "video/3gpp");
                    dict_types.Add("3gp", "video/3gpp");
                    dict_types.Add("ts", "video/mp2t");
                    dict_types.Add("mp4", "video/mp4");
                    dict_types.Add("mpg", "video/mpeg");
                    dict_types.Add("mpeg", "video/mpeg");
                    dict_types.Add("mov", "video/quicktime");
                    dict_types.Add("webm", "video/webm");
                    dict_types.Add("flv", "video/x-flv");
                    dict_types.Add("m4v", "video/x-m4v");
                    dict_types.Add("mng", "video/x-mng");
                    dict_types.Add("asx", "video/x-ms-asf");
                    dict_types.Add("asf", "video/x-ms-asf");
                    dict_types.Add("wmv", "video/x-ms-wmv");
                    dict_types.Add("avi", "video/x-msvideo");
                }
                #endregion
                return dict_types;
            }
        }

        /// <summary>
        /// 根据后缀名得到mime类型
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string GetType(string ext)
        {
            if (string.IsNullOrEmpty(ext))
            {
                return string.Empty;
            }
            ext = ext.ToLower();
            if (ext.StartsWith("."))
            {
                ext = ext.Remove(0, 1);
            }
            return Types[ext];
        }
    }
}