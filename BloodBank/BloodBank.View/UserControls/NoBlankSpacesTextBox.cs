using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BloodBank.View.UserControls
{
    class NoBlankSpacesTextBox : TextBox
    {
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            Text = string.IsNullOrWhiteSpace(Text) ? null : new string(Text.Where(c => !char.IsWhiteSpace(c)).ToArray());
            if (Text == null)
                return;
            SelectionStart = Text.Length;
        }
    }
}
