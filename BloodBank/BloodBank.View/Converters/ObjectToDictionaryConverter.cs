using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace BloodBank.View.Converters
{
    public class ObjectToDictionaryConverter : IValueConverter {
        internal static ObjectToDictionaryConverter Instance = new ObjectToDictionaryConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(value, null));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}