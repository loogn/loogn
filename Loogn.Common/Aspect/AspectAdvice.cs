using System;
using System.Reflection;

namespace Loogn.Common.Aspect
{
    /// <summary>
    /// 切面通知基类
    /// </summary>
    public interface IAspectAdvice
    {
        void Before(object target, MethodInfo mi, params object[] args);
        void After(object target, MethodInfo mi, params object[] args);
        void Throw(object target, MethodInfo mi, params object[] args);
    }
}
