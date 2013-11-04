using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Loogn.Common
{
    public static class PageHelper
    {
        public static Page CurrentPage
        {
            get
            {
                if (HttpContext.Current != null)
                    return HttpContext.Current.Handler as Page;
                else
                    return null;
            }
        }


        #region 页面Eval的强类型写法

        public static object EvalFunc<T>(this Page page, Func<T, object> func)
        {
            object obj = page.GetDataItem();
            return func((T)obj);
        }
        public static object EvalFunc<T>(Func<T, object> func)
        {
            object obj = CurrentPage.GetDataItem();
            return func((T)obj);
        }
        public static T EvalModel<T>(this Page page)
        {
            return (T)page.GetDataItem();
        }
        public static T EvalModel<T>()
        {
            return (T)CurrentPage.GetDataItem();
        }

        #endregion

 
        #region 充值与显示

        /// <summary>
        /// 从一个DataTable填充页面Form里的控件
        /// </summary>
        /// <param name="dataTable">有一行数据的数据源</param>
        public static void ShowFromDataTable(DataTable dataTable)
        {
            Page page = HttpContext.Current.Handler as Page;
            ShowFromDataTable(dataTable, page.Form);
        }

        /// <summary>
        /// 从一个DataTable填充到页面里contain控件里的子控件
        /// </summary>
        /// <param name="dataTable">有一行数据的数据源</param>
        /// <param name="contain">容器控件</param>
        public static void ShowFromDataTable(DataTable dataTable, Control contain)
        {
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                foreach (DataColumn dc in dataTable.Columns)
                {
                    object val = dr[dc];
                    Control c = contain.FindControl("S_" + dc.ColumnName);
                    if (c == null)
                    {
                        c = contain.FindControl("V_" + dc.ColumnName);
                    }
                    if (c == null)
                    {
                        continue;
                    }
                    ITextControl tc = c as ITextControl;//TextBox/Lable/Literal
                    if (tc != null)
                    {
                        tc.Text = val.ToString();
                        continue;
                    }
                    DropDownList ddl = c as DropDownList;
                    if (ddl != null)
                    {
                        foreach (ListItem li in ddl.Items)
                        {
                            if (li.Value == val.ToString())
                            {
                                li.Selected = true;
                                continue;
                            }
                        }
                    }
                    HiddenField hf = c as HiddenField;
                    if (hf != null)
                    {
                        hf.Value = val.ToString();
                        continue;
                    }
                    CheckBox ckb = c as CheckBox;
                    if (ckb != null)
                    {
                        ckb.Checked = val.Equals(true);
                        continue;
                    }
                    HtmlGenericControl html = c as HtmlGenericControl;
                    if (html != null)
                    {
                        html.InnerHtml = val.ToString();
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 从一个实体类填充到页面里contain控件里的子控件
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="contain">容器控件</param>
        public static void ShowFromEntity(object entity, Control contain)
        {
            if (entity == null)
                return;
            Type type = entity.GetType();
            foreach (PropertyInfo pinfo in type.GetProperties())
            {
                object objval = pinfo.GetValue(entity, null);
                if (objval == null)
                    continue;
                string val = objval.ToString();
                Control c = contain.FindControl("S_" + pinfo.Name);
                if (c == null)
                {
                    c = contain.FindControl("V_" + pinfo.Name);
                }
                if (c == null)
                {
                    continue;
                }
                ITextControl tc = c as ITextControl;
                if (tc != null)
                {
                    tc.Text = val;
                }
                DropDownList ddl = c as DropDownList;
                if (ddl != null)
                {
                    foreach (ListItem li in ddl.Items)
                    {
                        if (li.Value == val)
                        {
                            li.Selected = true;
                            continue;
                        }
                    }
                }
                HiddenField hf = c as HiddenField;
                if (hf != null)
                {
                    hf.Value = val;
                    continue;
                }
                CheckBox ckb = c as CheckBox;
                if (ckb != null)
                {
                    ckb.Checked = objval.Equals(true) || objval.Equals("1") || objval.Equals(1);
                    continue;
                }
            }
        }

        /// <summary>
        /// 从一个实体类填充页面Form里的控件
        /// </summary>
        /// <param name="entity">实体对象</param>
        public static void ShowFromEntity(object entity)
        {
            Page page = HttpContext.Current.Handler as Page;
            ShowFromEntity(entity, page.Form);
        }

        /// <summary>
        /// 从一个DataRow填充一个实体
        /// </summary>
        /// <param name="entity">目标对象</param>
        /// <param name="dr">数据行</param>
        public static void FillEntityFromDataRow(object entity, DataRow dr)
        {
            Type type = entity.GetType();
            foreach (DataColumn c in dr.Table.Columns)
            {
                string cname = c.ColumnName;
                if (dr[cname] != null)
                {
                    PropertyInfo property = type.GetProperty(cname);
                    if (property != null)
                    {
                        Type ptype = type.GetProperty(cname).PropertyType;
                        if (dr[cname] is DBNull)
                        {
                            property.SetValue(entity, null, null);
                        }
                        else
                        {
                            property.SetValue(entity, Convert.ChangeType(dr[cname], ptype), null);
                        }
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 从一个DataTable填充一个实体类集合
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="entities">目标对象集合</param>
        /// <param name="dt">DataTable</param>
        public static void FillEntitiesFromDataTable<T>(IList<T> entities, DataTable dt) where T : class
        {
            if (entities == null)
            {
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                ConstructorInfo cinfo = typeof(T).GetConstructor(Type.EmptyTypes);
                T obj = (T)cinfo.Invoke(null);
                FillEntityFromDataRow(obj, dr);
                entities.Add(obj);
            }
        }

        /// <summary>
        /// 用页面中一个控件的子控件填充一个实体类
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="contain">容器控件</param>
        public static void FillEntityFromControl(object entity, Control contain)
        {
            ControlCollection controls = contain.Controls;
            Type type = entity.GetType();
            foreach (Control c in controls)
            {
                string id = c.ID;
                if (id != null && id.StartsWith("S_"))
                {
                    string propertyName = id.Substring(2);
                    PropertyInfo property = type.GetProperty(propertyName);
                    Type ptype = type.GetProperty(propertyName).PropertyType;
                    ITextControl tc = c as ITextControl;
                    if (tc != null)
                    {
                        property.SetValue(entity, Convert.ChangeType(tc.Text, ptype), null);
                        continue;
                    }
                    DropDownList ddl = c as DropDownList;
                    if (ddl != null)
                    {
                        property.SetValue(entity, Convert.ChangeType(ddl.SelectedValue, ptype), null);
                        continue;
                    }
                    CheckBox cb = c as CheckBox;
                    if (cb != null)
                    {
                        property.SetValue(entity, Convert.ChangeType(cb.Checked, ptype), null);
                        continue;
                    }
                    HiddenField hf = c as HiddenField;
                    if (hf != null)
                    {
                        property.SetValue(entity, Convert.ChangeType(hf.Value, ptype), null);
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 用页面Form中的子控件填充一个实体类
        /// </summary>
        /// <param name="entity">实体对象</param>
        public static void FillEntityFromPage(object entity)
        {
            Page page = HttpContext.Current.Handler as Page;
            FillEntityFromControl(entity, page.Form);
        }

        #endregion

        #region 操作url

        /// <summary>
        /// 设置URL的参数
        /// 用Request.Url做为处理的url来处理,Request.Url的形式为绝对路径
        /// </summary>
        /// <param name="key">要设置的key</param>
        /// <param name="value">要赋的值</param>
        /// <returns></returns>
        public static string SetUrlParams(string key, string value)
        {
            return SetUrlParams(key, value, HttpContext.Current.Request.Url.ToString(), false);
        }
        
        /// <summary>
        /// 设置URL的参数,value为urlEncode编码
        /// 用Request.Url做为处理的url来处理,Request.Url的形式为绝对路径
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="urlEncode"></param>
        /// <returns></returns>
        public static string SetUrlParams(string key, string value, bool urlEncode)
        {
            return SetUrlParams(key, value, HttpContext.Current.Request.Url.ToString(), true);
        }
        
        /// <summary>
        /// 设置URL的参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="url">url</param>
        /// <returns></returns>
        public static string SetUrlParams(string key, string value, string url)
        {
            return SetUrlParams(key, value, url, false);
        }
        /// <summary>
        /// 设置URL的参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="url"></param>
        /// <param name="urlEncode"></param>
        /// <returns></returns>
        public static string SetUrlParams(string key, string value, string url, bool urlEncode)
        {
            if (urlEncode)
            {
                if (HttpContext.Current == null)
                {
                    throw new Exception("只有要页面的上下文中才可以用UrlEncode!");
                }
                else
                {
                    value = HttpContext.Current.Server.UrlEncode(value);
                }
            }
            int fragPos = url.LastIndexOf("#");
            string fragment = string.Empty;
            if (fragPos > -1)
            {
                fragment = url.Substring(fragPos);
                url = url.Substring(0, fragPos);
            }
            int querystart = url.IndexOf("?");
            if (querystart < 0)
            {
                url += "?" + key + "=" + value;
            }
            else
            {
                Regex reg = new Regex(@"(?<=[&\?])" + key + @"=[^\s&#]*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (reg.IsMatch(url))
                    url = reg.Replace(url, key + "=" + value);
                else
                    url += "&" + key + "=" + value;
            }
            return url + fragment;
        }

        /// <summary>
        /// 移除url的key参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RemoveUrlParams(string key, string url)
        {
            Regex reg = new Regex(@"[&\?]" + key + @"=[^\s&#]*&?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.Replace(url, new MatchEvaluator(PutAwayGarbageFromUrl));
        }

        private static string PutAwayGarbageFromUrl(Match match)
        {
            string value = match.Value;
            if (value.EndsWith("&"))
                return value.Substring(0, 1);
            else
                return string.Empty;
        }

        #endregion

        #region 在请求上下求执行用户控件
        public static string LoadUserControl<T>(string virtualPath,Action<T> act) where T : UserControl
        {
            Page p = new Page();
            IHttpHandler oldHandler = HttpContext.Current.Handler;//上下文转换
            HttpContext.Current.Handler = p;
            
            var control=p.LoadControl(virtualPath);
            T uc;
            if (control is PartialCachingControl)
            {
                uc = (T)((PartialCachingControl)control).CachedControl;
            }
            else
            {
                uc = (T)control;
            }
            
            act(uc);
            p.Controls.Add(uc);
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.Execute(p, writer, false);

            HttpContext.Current.Handler = oldHandler;
            return writer.ToString();
        }
        public static string LoadUserControl(string virtualPath)
        {
            Page p = new Page();
            IHttpHandler oldHandler = HttpContext.Current.Handler;//上下文转换
            HttpContext.Current.Handler = p;

            Control uc = p.LoadControl(virtualPath);

            p.Controls.Add(uc);
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.Execute(p, writer, false);

            HttpContext.Current.Handler = oldHandler;
            return writer.ToString();
        }
        #endregion

        #region js
        /// <summary>
        /// 在页面开始输出js脚本
        /// </summary>
        /// <param name="script">脚本内容</param>
        public static void WriteScript(string script)
        {
            CurrentPage.Response.Write(string.Format("<script type=\"text/javascript\">{0}</script>", script));
        }
        /// <summary>
        /// 在页面开始输出文本
        /// </summary>
        /// <param name="content">文本内容</param>
        public static void Write(string content)
        {
            CurrentPage.Response.Write(content);
        }
        /// <summary>
        /// 在页面开始输出js提示框
        /// </summary>
        /// <param name="msg">提示内容</param>
        public static void WriteAlert(string msg)
        {
            Write(string.Format("<script type=\"text/javascript\">alert(\"{0}\")</script>", msg));
        }
        /// <summary>
        /// 在页面开始输出js跳转
        /// </summary>
        /// <param name="url">跳转地址</param>
        public static void WriteGoTo(string url)
        {
            WriteScript("location.href=\"" + url + "\"");
        }
        /// <summary>
        /// 在页面开始输出js提示框和js跳转
        /// </summary>
        /// <param name="msg">提示内容</param>
        /// <param name="url">跳转地址</param>
        public static void WriteAlertAandGoTo(string msg, string url)
        {
            WriteScript(string.Format("alert(\"{0}\");location.href=\"{1}\"", msg, url));
        }

        /// <summary>
        /// 向页面中注册js脚本
        /// </summary>
        /// <param name="js">脚本内容</param>
        public static void RegisterScript(string js)
        {
            CurrentPage.ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), string.Format("<script type=\"text/javascript\">{0}</script>", js));
        }

        /// <summary>
        /// 以注册脚本形式弹出提示框
        /// </summary>
        /// <param name="msg">信息</param>
        public static void Alert(string msg)
        {
            RegisterScript(string.Format("alert(\"{0}\")", msg));
        }
        /// <summary>
        /// 以注册脚本形式跳转页面
        /// </summary>
        /// <param name="url">目标页面地址</param>
        public static void GoTo(string url)
        {
            RegisterScript(string.Format("location.href=\"{0}\"", url));
        }
        /// <summary>
        /// 以注册脚本形式弹出提示框并跳转页面
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="url">目标页面地址</param>
        public static void AlertAndGoTo(string msg, string url)
        {
            RegisterScript(string.Format("alert(\"{0}\");location.href=\"{1}\"", msg, url));
        }

        #endregion
    }
}
