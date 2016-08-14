using System;
using System.Globalization;
using System.Windows.Data;

namespace BloodBank.View.Converters {

    public class BoolToValueConverter<T> : IValueConverter {
        public T FalseValue { get; set; }
        public T TrueValue { get; set; }
        public T NullValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            bool? myBool = value as bool?;
            return myBool == null ? NullValue : myBool.Value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture) {
            if (value.Equals(NullValue))
                return null;
            return value.Equals(TrueValue);
        }
    }
}