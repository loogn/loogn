using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.IO;
using System.Data;

namespace Loogn.Common
{
    /// <summary>
    /// 导出操作类
    /// </summary>
    public class ExportHelper
    {
        #region 控件导出Word
        /// <summary>
        /// 将Control里呈现的内容导出到Word文档
        /// </summary>
        /// <param name="control">要导出内容的控件</param>
        public static void ToWord(Control control)
        {
            HttpContext curContext = System.Web.HttpContext.Current;
            StringWriter strWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter);
            curContext.Response.ClearContent();
            curContext.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.doc", getTimeName()));
            curContext.Response.ContentType = "application/vnd.ms-word";
            curContext.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            curContext.Response.Charset = "GB2312";
            control.RenderControl(htmlWriter);
            curContext.Response.Write(strWriter.ToString());
            curContext.Response.End();
        }
        #endregion

        #region 控件导出Excel
        /// <summary>
        /// 将Control里呈现的内容导出到Excel表格
        /// </summary>
        /// <param name="control">要导出内容的控件</param>
        public static void ToExcel(Control control)
        {
            HttpContext curContext = System.Web.HttpContext.Current;
            StringWriter strWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter);
            curContext.Response.ClearContent();
            curContext.Response.AddHeader("content-disposition", string.Format ("attachment; filename={0}.xls",getTimeName()));
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            curContext.Response.Charset = "GB2312";
            control.RenderControl(htmlWriter);
            curContext.Response.Write(strWriter.ToString());
            curContext.Response.End();
        }
        #endregion

        private static string getTimeName()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmsstttt");
        }
    }

}
