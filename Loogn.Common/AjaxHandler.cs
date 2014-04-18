using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.Common
{
    /// <summary>
    /// 用户处理ajax请求
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public delegate string AjaxHandler(params object[] args);

    /// <summary>
    /// AjaxHandlerHelper
    /// </summary>
    public class AjaxHandlerHelper
    {
        /// <summary>
        /// 得到type类型里静态私有方法字典
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<string, AjaxHandler> BuildHandlers(Type type)
        {
            Dictionary<string, AjaxHandler> hs = new Dictionary<string, AjaxHandler>();
            var msArr = type.GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            for (int i = 0; i < msArr.Length; i++)
            {
                //以下两个变量和下面的lambda有点闭包的味道
                var ms = msArr[i];
                var ps = ms.GetParameters();
                hs.Add(ms.Name.ToLower(), (args) =>
                {
                    //如果无参数
                    if (ps.Length == 0)
                    {
                        return ms.Invoke(null, null).ToString();
                    }
                    //如果有参数，先设置为默认值
                    var objs = new object[ps.Length];
                    for (int j = 0; j < ps.Length; j++)
                    {
                        objs[j] = ps[j].DefaultValue;
                    }
                    //处理实参
                    if (args != null && args.Length > 0)
                    {
                        for (int k = 0; k < args.Length; k++)
                        {
                            var val=args[k];
                            if (!(DBNull.Value.Equals(val)))
                            {
                                objs[k] = args[k];
                            }
                        }
                    }
                    return ms.Invoke(null, objs).ToString();
                });
            }
            return hs;
        }
    }
}
