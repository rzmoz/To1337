using System;
using System.Collections.Generic;

namespace To1337.Rulez
{
    internal static class RulezExtensions
    {
        internal static T ToEnum<T>(this string enumValue, bool ignoreCase = true) where T : struct
        {
            if (!typeof(T).IsEnum) throw new NotSupportedException();
            return (T)Enum.Parse(typeof(T), enumValue, ignoreCase);
        }

        internal static bool SequentialEquals<T>(this IReadOnlyCollection<T> enumerable, IReadOnlyCollection<T> otherEnumerable)
        {
            using (var enum1 = enumerable.GetEnumerator())
            using (var enum2 = otherEnumerable.GetEnumerator())
            {
                while (enum1.MoveNext() && enum2.MoveNext())
                {
                    //if one of the elements are not the same, then we quit immediately
                    if (!enum1.Current.Equals(enum2.Current))
                        return false;
                }
            }
            return true;
        }
    }
}
