using System;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.ViewModels;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel {
    [ImplementPropertyChanged]
    public class ShellViewModel : Conductor<NavigationMenuItem>.Collection.OneActive, IHandle<NavMenuEvent> {
        public ShellViewModel(IEventAggregator eventAggregator, DonatoriViewModel donatoriViewModel, DonazioniViewModel donazioniViewModel)
        {
            eventAggregator.Subscribe(this);

            DisplayName = "BloodBank";

            Items.Add(new NavigationMenuItem("Donatori", "AccountMultiple", donatoriViewModel));
            Items.Add(new NavigationMenuItem("Donazioni", "Heart", donazioniViewModel));
        }

        #region NavMenu

        public bool IsNavMenuOpen { get; set; }

        public void CloseNavMenu() {
            IsNavMenuOpen = false;
        }

        public void Handle(NavMenuEvent message) {
            switch (message.ChangeTo) {
                case NavMenuEvent.NavMenuStates.Toggle:
                    IsNavMenuOpen = !IsNavMenuOpen;
                    break;
                case NavMenuEvent.NavMenuStates.Open:
                    IsNavMenuOpen = true;
                    break;
                case NavMenuEvent.NavMenuStates.Close:
                    IsNavMenuOpen = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }


}
