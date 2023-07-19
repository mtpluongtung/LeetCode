using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Extension
{
    public static class ObjectExtension
    {
        public static object? GetPropertyValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }

        public static object? ToType(this object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
#pragma warning disable CS8601 // Possible null reference assignment.
        public static object CreateDynamicObject<T>(Dictionary<string, T> keyValuePairs)
        {
            dynamic expando = new ExpandoObject();
            foreach (var keyValuePair in keyValuePairs)
            {

                ((IDictionary<String, object>)expando)[keyValuePair.Key] = keyValuePair.Value;

            }

            return expando;
        }
#pragma warning restore CS8601 // Possible null reference assignment.
    }
}
