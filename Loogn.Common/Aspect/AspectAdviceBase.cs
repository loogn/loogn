using System;
using System.Reflection;

namespace Loogn.Common.Aspect
{
    /// <summary>
    /// 切面通知基类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public abstract class AspectAdviceBase : Attribute
    {
        /// <summary>
        /// 后调用
        /// </summary>
        /// <param name="target"></param>
        /// <param name="mi"></param>
        /// <param name="args"></param>
        public virtual void After(object target, MethodInfo mi, params object[] args)
        {
        }

        /// <summary>
        /// 前调用
        /// </summary>
        /// <param name="target"></param>
        /// <param name="mi"></param>
        /// <param name="args"></param>
        public virtual void Before(object target, MethodInfo mi, params object[] args)
        {
        }

        /// <summary>
        /// 异常调用
        /// </summary>
        /// <param name="target"></param>
        /// <param name="mi"></param>
        /// <param name="args"></param>
        public virtual void Throw(object target, MethodInfo mi, params object[] args)
        {
        }
    }
}
