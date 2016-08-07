using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BloodBank.View.UserControls {

    public class LayoutSetter {

        public static Thickness GetMargin(DependencyObject obj) {
            return (Thickness) obj.GetValue(MarginProperty);
        }

        public static void SetMargin(DependencyObject obj, Thickness value) {
            obj.SetValue(MarginProperty, value);
        }

        // Using a DependencyProperty as the backing store for Margin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarginProperty =
            DependencyProperty.RegisterAttached("Margin", typeof(Thickness), typeof(LayoutSetter), new UIPropertyMetadata(new Thickness(), MarginChangedCallback));

        public static void MarginChangedCallback(object sender, DependencyPropertyChangedEventArgs e) {
            // Make sure this is put on a panel
            Panel panel = sender as Panel;
            if (panel == null)
                return;

            panel.Loaded += PanelLoaded;
        }

        private static void PanelLoaded(object sender, RoutedEventArgs e) {
            Panel panel = sender as Panel;

            // Go over the children and set margin for them:
            Debug.Assert(panel != null, "panel != null");
            foreach (FrameworkElement fe in panel.Children.OfType<FrameworkElement>())
                fe.Margin = GetMargin(panel);
        }
    }
}