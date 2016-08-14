using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class DonazioniViewModel : Screen {
        private readonly IEventAggregator _eventAggregator;

        #region Constructors
        public DonazioniViewModel(IEventAggregator eventAggregator){
            _eventAggregator = eventAggregator;
            DisplayName = "Donazioni";
        }
        #endregion

        #region Actions
        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }
        #endregion

    }
}
