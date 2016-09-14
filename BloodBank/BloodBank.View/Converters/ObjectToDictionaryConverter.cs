using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;

namespace BloodBank.View.Converters {
    public class ObjectToDictionaryConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(value, null));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}
