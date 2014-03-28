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
}
