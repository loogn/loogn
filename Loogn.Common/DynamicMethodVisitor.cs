using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Linq.Expressions;

namespace Loogn.Common
{
    /// <summary>
    /// 动态访问执行者
    /// </summary>
    public static class DynamicMethodVisitor
    {
        #region Lambda得到方法委托

        public static Func<object, object[], object> GetMethodHandlerByLadbda(MethodInfo methodInfo)
        {
            Func<object ,object[],object> handler;
            //parameters to execute;
            ParameterExpression instanceParameter =
                Expression.Parameter(typeof(object), "instance");
            ParameterExpression parametersParameter =
                Expression.Parameter(typeof(object[]), "parameters");

            //build parameter list
            List<Expression> parameterExpressions = new List<Expression>();
            ParameterInfo[] paramInfos = methodInfo.GetParameters();
            for (int i = 0; i < paramInfos.Length; i++)
            {
                BinaryExpression valueObj = Expression.ArrayIndex(parametersParameter,
                    Expression.Constant(i));
                UnaryExpression valueCast = Expression.Convert(
                    valueObj, paramInfos[i].ParameterType
                    );
                parameterExpressions.Add(valueCast);
            }


            Expression instanceCast = methodInfo.IsStatic ? null :
                Expression.Convert(instanceParameter, methodInfo.ReflectedType);

            MethodCallExpression methodCall = Expression.Call(
                    instanceCast, methodInfo, parameterExpressions
                );

            if (methodCall.Type == typeof(void))
            {
                Expression<Action<object, object[]>> lambda =
                    Expression.Lambda<Action<object, object[]>>(
                        methodCall, instanceParameter, parametersParameter
                    );
                Action<object, object[]> execute = lambda.Compile();
                handler= (instance, parameters) =>
                    {
                        execute(instance, parameters);
                        return null;
                    };
            }
            else
            {
                UnaryExpression castMethodCall = Expression.Convert(
                    methodCall, typeof(object));
                Expression<Func<object, object[], object>> lambda =
                    Expression.Lambda<Func<object, object[], object>>(
                        castMethodCall, instanceParameter, parametersParameter);
                handler = lambda.Compile();
            }
            return handler;
            
        }

        #endregion

        #region Emit得到方法委托

        public static Func<object, object[], object> GetMethodHandlerByEmit(MethodInfo methodInfo)
        {
            DynamicMethod dynamicMethod = new DynamicMethod(string.Empty,
                             typeof(object), new Type[] { typeof(object), 
                     typeof(object[]) },
                             methodInfo.DeclaringType.Module);
            ILGenerator il = dynamicMethod.GetILGenerator();
            ParameterInfo[] ps = methodInfo.GetParameters();
            Type[] paramTypes = new Type[ps.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                paramTypes[i] = ps[i].ParameterType;
            }
            LocalBuilder[] locals = new LocalBuilder[paramTypes.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                locals[i] = il.DeclareLocal(paramTypes[i]);
            }
            for (int i = 0; i < paramTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_1);
                EmitFastInt(il, i);
                il.Emit(OpCodes.Ldelem_Ref);
                EmitCastToReference(il, paramTypes[i]);
                il.Emit(OpCodes.Stloc, locals[i]);
            }
            il.Emit(OpCodes.Ldarg_0);
            for (int i = 0; i < paramTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldloc, locals[i]);
            }
            il.EmitCall(OpCodes.Call, methodInfo, null);
            if (methodInfo.ReturnType == typeof(void))
                il.Emit(OpCodes.Ldnull);
            else
                EmitBoxIfNeeded(il, methodInfo.ReturnType);
            il.Emit(OpCodes.Ret);
            Func<object, object[], object> invoder =
              (Func<object, object[], object>)dynamicMethod.CreateDelegate(
              typeof(Func<object, object[], object>));
            return invoder;
        }
        private static void EmitCastToReference(ILGenerator il, System.Type type)
        {
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, type);
            }
            else
            {
                il.Emit(OpCodes.Castclass, type);
            }
        }
        private static void EmitBoxIfNeeded(ILGenerator il, System.Type type)
        {
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Box, type);
            }
        }
        private static void EmitFastInt(ILGenerator il, int value)
        {
            switch (value)
            {
                case -1:
                    il.Emit(OpCodes.Ldc_I4_M1);
                    return;
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    return;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    return;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    return;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    return;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    return;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    return;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    return;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    return;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    return;
            }

            if (value > -129 && value < 128)
            {
                il.Emit(OpCodes.Ldc_I4_S, (SByte)value);
            }
            else
            {
                il.Emit(OpCodes.Ldc_I4, value);
            }
        }

        #endregion 

        #region 得到公开成员Get访问器

        public static Func<ObjectType, MemberType> GetMemberGetHandler<ObjectType, MemberType>(string memberName)
        {
            Type objectType = typeof(ObjectType);
            PropertyInfo pi = objectType.GetProperty(memberName);
            FieldInfo fi = objectType.GetField(memberName);
            if (pi != null)
            {
                MethodInfo mi = pi.GetGetMethod();
                if (mi != null)
                {
                    return (Func<ObjectType, MemberType>)Delegate.CreateDelegate(typeof(Func<ObjectType, MemberType>), mi);
                }
                else
                {
                    throw new Exception(String.Format("类型'{0}' 的属性'{1}' 没有一个公开的Get访问器", objectType.Name, memberName));
                }
            }
            else if (fi != null)
            {
                DynamicMethod dm = new DynamicMethod("Get" + memberName, typeof(MemberType), new Type[] { objectType }, objectType);
                ILGenerator il = dm.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, fi);
                il.Emit(OpCodes.Ret);
                return (Func<ObjectType, MemberType>)dm.CreateDelegate(typeof(Func<ObjectType, MemberType>));
            }
            else
            {
                throw new Exception(String.Format("成员'{0}'不是类型'{1}' 的公开属性或字段", memberName, objectType.Name));
            }
        }

        #endregion
    }
}
