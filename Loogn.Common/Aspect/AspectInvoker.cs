using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.Common.Aspect
{
    /// <summary>
    /// 调用类
    /// </summary>
    public static class AspectInvoker
    {

        #region Action

        #region BeforeAction
        public static void BeforeAction(Action act)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method);
            }
            act();
        }
        public static void BeforeAction<T>(Action<T> act, T t)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t);
            }
            act(t);
        }
        public static void BeforeAction<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2);
            }
            act(t1, t2);
        }
        public static void BeforeAction<T1, T2, T3>(Action<T1, T2, T3> act, T1 t1, T2 t2, T3 t3)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3);
            }
            act(t1, t2, t3);
        }
        public static void BeforeAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> act, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4);
            }
            act(t1, t2, t3, t4);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5);
            }
            act(t1, t2, t3, t4, t5);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
            }
            act(t1, t2, t3, t4, t5, t6);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t7);
            }
            act(t1, t2, t3, t4, t5, t6, t7);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        }
        public static void BeforeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
        }
        #endregion

        #region AfterAction
        public static void AfterAction(Action act)
        {
            act();
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method);
            }
        }
        public static void AfterAction<T>(Action<T> act, T t)
        {
            act(t);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t);
            }
        }
        public static void AfterAction<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2)
        {
            act(t1, t2);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2);
            }
        }
        public static void AfterAction<T1, T2, T3>(Action<T1, T2, T3> act, T1 t1, T2 t2, T3 t3)
        {
            act(t1, t2, t3);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3);
            }
        }
        public static void AfterAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> act, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            act(t1, t2, t3, t4);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            act(t1, t2, t3, t4, t5);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            act(t1, t2, t3, t4, t5, t6);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            act(t1, t2, t3, t4, t5, t6, t7);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
        }
        public static void AfterAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
        }
        #endregion

        #region AfterEnsureAction
        public static void AfterEnsureAction(Action act)
        {
            try
            {
                act();
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method);
                }
            }
        }
        public static void AfterEnsureAction<T>(Action<T> act, T t)
        {
            try
            {
                act(t);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2)
        {
            try
            {
                act(t1, t2);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3>(Action<T1, T2, T3> act, T1 t1, T2 t2, T3 t3)
        {
            try
            {
                act(t1, t2, t3);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> act, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            try
            {
                act(t1, t2, t3, t4);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            try
            {
                act(t1, t2, t3, t4, t5);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
                }
            }
        }
        public static void AfterEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
                }
            }
        }
        #endregion

        #region AroundAction
        public static void AroundAction(Action act)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method);
            }
            act();
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method);
            }
        }
        public static void AroundAction<T>(Action<T> act, T t)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t);
            }
            act(t);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t);
            }
        }
        public static void AroundAction<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2);
            }
            act(t1, t2);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2);
            }
        }
        public static void AroundAction<T1, T2, T3>(Action<T1, T2, T3> act, T1 t1, T2 t2, T3 t3)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3);
            }
            act(t1, t2, t3);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3);
            }
        }
        public static void AroundAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> act, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4);
            }
            act(t1, t2, t3, t4);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5);
            }
            act(t1, t2, t3, t4, t5);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
            }
            act(t1, t2, t3, t4, t5, t6);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7);
            }
            act(t1, t2, t3, t4, t5, t6, t7);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
        }
        public static void AroundAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            foreach (var advice in GetAdvices(act))
            {
                advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
        }
        #endregion

        #region AroundEnsureAction
        public static void AroundEnsureAction(Action act)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method);
            }
            try
            {
                act();
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method);
                }
            }
        }
        public static void AroundEnsureAction<T>(Action<T> act, T t)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t);
            }
            try
            {
                act(t);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2);
            }
            try
            {
                act(t1, t2);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3>(Action<T1, T2, T3> act, T1 t1, T2 t2, T3 t3)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3);
            }
            try
            {
                act(t1, t2, t3);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> act, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4);
            }
            try
            {
                act(t1, t2, t3, t4);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5);
            }
            try
            {
                act(t1, t2, t3, t4, t5);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
                }
            }
        }
        public static void AroundEnsureAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            foreach (var advice in GetAdvices(act))
            {
                advice.Before(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            finally
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.After(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
                }
            }
        }
        #endregion

        #region ThrowAction
        public static void ThrowAction(Action act)
        {
            try
            {
                act();
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T>(Action<T> act, T t)
        {
            try
            {
                act(t);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2)
        {
            try
            {
                act(t1, t2);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3>(Action<T1, T2, T3> act, T1 t1, T2 t2, T3 t3)
        {
            try
            {
                act(t1, t2, t3);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> act, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            try
            {
                act(t1, t2, t3, t4);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            try
            {
                act(t1, t2, t3, t4, t5);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
                }
                throw exp;
            }
        }
        public static void ThrowAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> act, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            try
            {
                act(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(act))
                {
                    advice.Throw(act.Target, act.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
                }
                throw exp;
            }
        }
        #endregion

        #endregion

        #region Func

        #region BeforeFunc
        public static TResult BeforeFunc<TResult>(Func<TResult> fun)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method);
            }
            return fun();
        }
        public static TResult BeforeFunc<T, TResult>(Func<T, TResult> fun, T t)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t);
            }
            return fun(t);
        }
        public static TResult BeforeFunc<T1, T2, TResult>(Func<T1, T2, TResult> fun, T1 t1, T2 t2)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2);
            }
            return fun(t1, t2);
        }
        public static TResult BeforeFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun, T1 t1, T2 t2, T3 t3)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3);
            }
            return fun(t1, t2, t3);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4);
            }
            return fun(t1, t2, t3, t4);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5);
            }
            return fun(t1, t2, t3, t4, t5);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
            }
            return fun(t1, t2, t3, t4, t5, t6);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        }
        public static TResult BeforeFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
        }
        #endregion

        #region AfterFunc
        public static TResult AfterFunc<TResult>(Func<TResult> fun)
        {
            var result = fun();
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method);
            }
            return result;
        }
        public static TResult AfterFunc<T, TResult>(Func<T, TResult> fun, T t)
        {
            var result = fun(t);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, TResult>(Func<T1, T2, TResult> fun, T1 t1, T2 t2)
        {
            var result = fun(t1, t2);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun, T1 t1, T2 t2, T3 t3)
        {
            var result = fun(t1, t2, t3);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            var result = fun(t1, t2, t3, t4);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            var result = fun(t1, t2, t3, t4, t5);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            var result = fun(t1, t2, t3, t4, t5, t6);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
            }
            return result;
        }
        public static TResult AfterFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            return result;
        }
        #endregion

        #region AfterEnsureFunc
        public static TResult AfterEnsureFunc<TResult>(Func<TResult> fun)
        {
            try
            {
                return fun();
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method);
                }
            }
        }
        public static TResult AfterEnsureFunc<T, TResult>(Func<T, TResult> fun, T t)
        {
            try
            {
                return fun(t);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, TResult>(Func<T1, T2, TResult> fun, T1 t1, T2 t2)
        {
            try
            {
                return fun(t1, t2);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun, T1 t1, T2 t2, T3 t3)
        {
            try
            {
                return fun(t1, t2, t3);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            try
            {
                return fun(t1, t2, t3, t4);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
                }
            }

        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
                }
            }

        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
                }
            }
        }
        public static TResult AfterEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
                }
            }
        }
        #endregion

        #region AroundFunc
        public static TResult AroundFunc<TResult>(Func<TResult> fun)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method);
            }
            var result = fun();
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method);
            }
            return result;
        }
        public static TResult AroundFunc<T, TResult>(Func<T, TResult> fun, T t)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t);
            }
            var result = fun(t);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, TResult>(Func<T1, T2, TResult> fun, T1 t1, T2 t2)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2);
            }
            var result = fun(t1, t2);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun, T1 t1, T2 t2, T3 t3)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3);
            }
            var result = fun(t1, t2, t3);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4);
            }
            var result = fun(t1, t2, t3, t4);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5);
            }
            var result = fun(t1, t2, t3, t4, t5);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
            }
            var result = fun(t1, t2, t3, t4, t5, t6);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
            }
            return result;
        }
        public static TResult AroundFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            var result = fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            foreach (var advice in GetAdvices(fun))
            {
                advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            return result;
        }
        #endregion

        #region AroundEnsureFunc
        public static TResult AroundEnsureFunc<TResult>(Func<TResult> fun)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method);
            }
            try
            {
                return fun();
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method);
                }
            }
        }
        public static TResult AroundEnsureFunc<T, TResult>(Func<T, TResult> fun, T t)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t);
            }
            try
            {
                return fun(t);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, TResult>(Func<T1, T2, TResult> fun, T1 t1, T2 t2)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2);
            }
            try
            {
                return fun(t1, t2);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun, T1 t1, T2 t2, T3 t3)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3);
            }
            try
            {
                return fun(t1, t2, t3);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4);
            }
            try
            {
                return fun(t1, t2, t3, t4);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
                }
            }

        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
                }
            }
        }
        public static TResult AroundEnsureFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            foreach (var advice in GetAdvices(fun))
            {
                advice.Before(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            finally
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.After(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
                }
            }
        }
        #endregion

        #region ThrowFunc
        public static TResult ThrowFunc<TResult>(Func<TResult> fun)
        {
            try
            {
                return fun();
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T, TResult>(Func<T, TResult> fun, T t)
        {
            try
            {
                return fun(t);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, TResult>(Func<T1, T2, TResult> fun, T1 t1, T2 t2)
        {
            try
            {
                return fun(t1, t2);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun, T1 t1, T2 t2, T3 t3)
        {
            try
            {
                return fun(t1, t2, t3);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            try
            {
                return fun(t1, t2, t3, t4);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t7);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t10, t11, t12, t13, t14, t15);
                }
                throw exp;
            }
        }
        public static TResult ThrowFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> fun, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            try
            {
                return fun(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            }
            catch (Exception exp)
            {
                foreach (var advice in GetAdvices(fun))
                {
                    advice.Throw(fun.Target, fun.Method, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
                }
                throw exp;
            }
        }
        #endregion

        #endregion


        static Dictionary<string, IEnumerable<AspectAdviceBase>> m_advices = new Dictionary<string, IEnumerable<AspectAdviceBase>>();

        static IEnumerable<AspectAdviceBase> GetAdvices(Delegate act)
        {
            var key = act.Method.DeclaringType.FullName + "." + act.Method.Name;
            if (m_advices.ContainsKey(key))
            {
                return m_advices[key];
            }
            else
            {
                var advices1 = act.Method.GetCustomAttributes(true);
                var advices2 = act.Method.DeclaringType.GetCustomAttributes(true);
                var advices = advices1.Concat(advices2).Cast<AspectAdviceBase>();
                m_advices[key] = advices;
                return advices;
            }
        }
    }
}
