using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : Conductor<IScreen>.Collection.OneActive {
        private readonly IEventAggregator _eventAggregator;

        #region Constructors
        public DonatoriViewModel(IEventAggregator eventAggregator, DonatoreViewModel d1, DonatoreViewModel d2){
            _eventAggregator = eventAggregator;

            DisplayName = "Donatori";

            Items.Add(d1);
            Items.Add(d2);
        }
        #endregion

        #region Actions
        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }
        #endregion

    }
}
