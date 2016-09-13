using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using ComboBox = System.Windows.Controls.ComboBox;
using TextBox = System.Windows.Controls.TextBox;

namespace BloodBank.View.Components {
    public class ReadOnlyPanel {
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.RegisterAttached(
                "IsReadOnly", typeof(bool), typeof(ReadOnlyPanel),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.Inherits, ReadOnlyPropertyChanged));

        public static bool GetIsReadOnly(DependencyObject o) {
            return (bool)o.GetValue(IsReadOnlyProperty);
        }

        public static void SetIsReadOnly(DependencyObject o, bool value) {
            o.SetValue(IsReadOnlyProperty, value);
        }

        private static void ReadOnlyPropertyChanged(
            DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (o.GetType().GetProperty("IsEnabled") != null) {
                o.GetType().GetProperty("IsEnabled").SetValue(o, !(bool)e.NewValue);
            }

        }
    }
}
