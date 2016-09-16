using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BloodBank.View.UserControls {

    public class FilteredEditableComboBox : ComboBox {

        public FilteredEditableComboBox()
        {
            IsEditable = true;
            GotFocus += myComboBox_GotFocus;
            KeyUp += myComboBox_KeyUp;
        }
        
        private int _lastMatchLength;

        private void myComboBox_GotFocus(object sender, RoutedEventArgs e) {
            _lastMatchLength = 0;
        }

        private void myComboBox_KeyUp(object sender, KeyEventArgs e) {
            ComboBox cBox = sender as ComboBox;

            TextBox tb = cBox?.Template.FindName("PART_EditableTextBox", cBox) as TextBox;
            if (tb != null) {
                if (cBox.SelectedIndex >= 0) {
                    _lastMatchLength = tb.SelectionStart;
                } else if (tb.Text.Length == 0) {
                    _lastMatchLength = 0;
                } else {
                    System.Media.SystemSounds.Beep.Play();
                    tb.Text = tb.Text.Substring(0, _lastMatchLength);
                    tb.CaretIndex = tb.Text.Length;
                }

                if (string.IsNullOrWhiteSpace(tb.Text))
                    SelectedItem = null;
            }
        }
    }
}
