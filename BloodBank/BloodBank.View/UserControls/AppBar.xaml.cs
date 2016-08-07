using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace BloodBank.View.UserControls {
    /// <summary>
    /// Interaction logic for AppBar.xaml
    /// </summary>
    public partial class AppBar : UserControl {

        public AppBar() {
            InitializeComponent();
        }

        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof (string), typeof (AppBar));

        public ShadowDepth Shadow {
            get { return (ShadowDepth)GetValue(ShadowProperty); }
            set { SetValue(ShadowProperty, value); }
        }
        public static readonly DependencyProperty ShadowProperty =
            DependencyProperty.Register("Shadow", typeof(ShadowDepth), typeof(AppBar), new PropertyMetadata(ShadowDepth.Depth1));

        public event RoutedEventHandler NavMenuButtonClickAction;
        private void OnNavMenuButtonClick(object sender, RoutedEventArgs e) {
            NavMenuButtonClickAction?.Invoke(this, e);
        }


    }
}
