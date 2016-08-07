using System;
using System.Globalization;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;

namespace BloodBank.View.Converters {
    public class StringToPackIconConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string iconName = value as string;
            if (iconName == null)
                throw new SystemException("Cannot convert non-string value");

            PackIconKind icon;
            bool result = Enum.TryParse(iconName, out icon);
            return result ? icon : PackIconKind.ArrowRight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
