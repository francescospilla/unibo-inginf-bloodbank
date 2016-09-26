using System.Linq;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BloodBank.View.Views.Indagini {
    /// <summary>
    /// Interaction logic for VoceView.xaml
    /// </summary>
    public partial class VoceView : UserControl {
        public VoceView() {
            InitializeComponent();
        }
        
        private void ComboBox_OnLoaded(object sender, RoutedEventArgs e) {
            ComboBox cBox = sender as ComboBox;

            if (cBox == null) return;

            cBox.IsEditable = cBox.ItemsSource.Cast<object>().Count() > 2;
        }
    }
}
