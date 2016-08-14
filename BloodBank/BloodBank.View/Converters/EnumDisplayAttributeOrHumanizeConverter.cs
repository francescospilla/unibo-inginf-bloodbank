using BloodBank.Core.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BloodBank.View.Converters {

    public class EnumDisplayAttributeOrHumanizeConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            Enum myEnum = value as Enum;
            return myEnum != null ? myEnum.NameOrDescription() ?? myEnum.ToString() : value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}