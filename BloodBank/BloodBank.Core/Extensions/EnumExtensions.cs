using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BloodBank.Core.Extensions {

    public static class EnumExtensions {
        private static readonly Random SeededRandom = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        
        public static string NameOrDescription(this Enum enumObj)
        {
            DisplayAttribute attribute = enumObj.GetType()
                .GetField(enumObj.ToString())
                ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() as DisplayAttribute;

                return attribute?.Name ?? attribute?.Description;
        }

        public static IEnumerable<T> Values<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T Random<T>()
        {
            T[] values = Values<T>().ToArray();
            return values[SeededRandom.Next(0, values.Length)];
        }

    }
}