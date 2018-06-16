using System;

namespace Observer.Core.Extensions
{
    public static class StringExtensions
    {
        public static TEnum ParseToEnum<TEnum>(this string value) => (TEnum)Enum.Parse(typeof(TEnum), value, true);
    }
}
