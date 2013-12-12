using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Loogn.Common
{
    public static class ExtensionMethods
    {
        #region IEnumerable<T>.Distinct
        private class EqualityComparer<TSource> : IEqualityComparer<TSource>
        {
            Func<TSource, TSource, bool> m_comparer;
            public EqualityComparer(Func<TSource, TSource, bool> comparer)
            {
                m_comparer = comparer;
            }
            public bool Equals(TSource x, TSource y)
            {
                if (x != null)
                {
                    return ((y != null) && this.m_comparer(x, y));
                }

                if (y != null)
                {
                    return false;
                }
                return true;
            }

            public int GetHashCode(TSource obj)
            {
                return 0;
            }
        }
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, bool> comparer)
        {
            return source.Distinct(new EqualityComparer<TSource>(comparer));
        }
        #endregion

        #region IEnumerable<T>.ForEach
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
        #endregion

        #region IEnumerable<T>.MapReduce
        public static Dictionary<TKey, TResult> MapReduce<TInput, TKey, TValue, TResult>(
            this IEnumerable<TInput> list,
            Func<TInput, IEnumerable<KeyValuePair<TKey, TValue>>> map,
            Func<TKey, IEnumerable<TValue>, TResult> reduce)
        {
            Dictionary<TKey, List<TValue>> mapResult = new Dictionary<TKey, List<TValue>>();
            foreach (var item in list)
            {
                foreach (var one in map(item))
                {
                    List<TValue> mapValues;
                    if (!mapResult.TryGetValue(one.Key, out mapValues))
                    {
                        mapValues = new List<TValue>();
                        mapResult.Add(one.Key, mapValues);
                    }
                    mapValues.Add(one.Value);
                }
            }
            var result = new Dictionary<TKey, TResult>();
            foreach (var m in mapResult)
            {
                result.Add(m.Key, reduce(m.Key, m.Value));
            }
            return result;
        }
        #endregion


        public static dynamic ToDynamic(this object instance)
        {
            var x = new System.Dynamic.ExpandoObject();
            var values =
                from property in instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                select new
                {
                    Name = property.Name,
                    Value = property.GetValue(instance, null)
                };
            foreach (var property in values)
                (x as IDictionary<string, object>).Add(property.Name, property.Value);
            return x;
        }


        public static int? AsInt32(this string s)
        {
            int result;
            if (int.TryParse(s, out result))
            {
                return result;
            }
            return null;
        }

        public static byte? AsByte(this string s)
        {
            byte result;
            if (byte.TryParse(s, out result))
            {
                return result;
            }
            return null;
        }

        public static DateTime? AsDateTime(this string s)
        {
            DateTime result;
            if (DateTime.TryParse(s, out result))
            {
                return result;
            }
            return null;
        }



    }
}
