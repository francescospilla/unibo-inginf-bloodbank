using System.Windows;
using System.Windows.Controls;

namespace BloodBank.View.Views.Indagini {
    /// <summary>
    /// Interaction logic for IndaginiView.xaml
    /// </summary>
    public partial class IndaginiView : UserControl {
        public IndaginiView() {
            InitializeComponent();

        }

        private void Grid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            DataGridTextColumn column = (DataGridTextColumn)e.Column;
            if (column != null)
                column.ElementStyle = Resources["WrappedTextBlockStyle"] as Style;
        }
    }
}
