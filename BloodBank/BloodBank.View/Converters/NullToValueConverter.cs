using System;
using System.Globalization;
using System.Windows.Data;

namespace BloodBank.View.Converters {

    public class NullToValue<T> : IValueConverter {
        public T FalseValue { get; set; }
        public T TrueValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value == null ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}