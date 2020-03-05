using System;
using System.Collections.Generic;
using System.Linq;

namespace DziennikSportowca.Common.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<T> GetAttributes<T>(this Enum @enum)
        {
            var enumType = @enum.GetType();
            var name = Enum.GetName(enumType, @enum);

            return enumType.GetField(name).GetCustomAttributes(false).OfType<T>();
        }
    }
}