using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Extension
{
    public static class TypeExtension
    {
        public static bool IsCastableTo(this Type from, Type to)
        {
            if (to.IsAssignableFrom(from))
            {
                return true;
            }
            return CheckConvertible(from, to);
        }

        public static bool CheckConvertible(Type fromType, Type toType)
        {
            Type converterType = typeof(TypeConverterChecker<,>).MakeGenericType(fromType, toType);

            object instance = Activator.CreateInstance(converterType);


            return (bool)converterType.GetProperty("CanConvert").GetGetMethod().Invoke(instance, null);


        }
    }
    public class TypeConverterChecker<TFrom, TTo>
    {
        public bool CanConvert { get; private set; }

        public TypeConverterChecker()
        {
            TFrom from = default(TFrom);
            if (from == null)
                if (typeof(TFrom).Equals(typeof(String)))
                    from = (TFrom)(dynamic)"";
                else
                    from = (TFrom)Activator.CreateInstance(typeof(TFrom));
            try
            {
                TTo to = (dynamic)from;
                CanConvert = true;
            }
            catch
            {
                CanConvert = false;
            }
        }
    }
}
