using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.Common
{
    /// <summary>
    /// 用户处理ajax请求
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public delegate string AjaxHandler(object state = null);

    public class AjaxHandlerHelper
    {
        public static Dictionary<string, AjaxHandler> BuildHandlers(Type type)
        {
            Dictionary<string, AjaxHandler> hs = new Dictionary<string, AjaxHandler>();
            var msArr = type.GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            for (int i = 0; i < msArr.Length; i++)
            {
                var ms = msArr[i];
                hs.Add(ms.Name.ToLower(), (obj) =>
                {
                    return ms.Invoke(null, new object[] { obj }).ToString();
                });
            }
            return hs;
        }
    }
}
