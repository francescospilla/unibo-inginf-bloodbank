using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    // TODO: FixMe?
    // Shameful hack dovuta al fatto che per qualche ragione la libreria Stylet lancia NullArgumentException a caso quando uno Screen
    // che usa i servizi di validazione offerti dalla libreria stessa è inserito in un TabControl o controllo simile con più figli.

    [ImplementPropertyChanged]
    public class TabWrapperViewModel : Conductor<IScreen> {
        private IScreen WrappedScreen { get; }
        
        public TabWrapperViewModel(IScreen wrappedScreen) {
            WrappedScreen = wrappedScreen;
            ActiveItem = WrappedScreen;
        }
    }
}
