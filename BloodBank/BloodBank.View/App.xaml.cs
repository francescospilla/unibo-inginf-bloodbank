using System.Globalization;
using System.Threading;
using System.Windows;

namespace BloodBank.View {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            // Forza locale it-IT per l'applicazione
            CultureInfo culture = CultureInfo.CreateSpecificCulture("it-IT");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            base.OnStartup(e);
        }
    }
}