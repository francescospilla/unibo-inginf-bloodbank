using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;
using System;
using BloodBank.Model.Donazioni;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.ViewModels;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class ShellViewModel : Conductor<NavigationMenuItem>.Collection.OneActive, IHandle<NavMenuEvent> {

        public ShellViewModel(IEventAggregator eventAggregator, DonatoriViewModel donatoriViewModel, DonazioniViewModel donazioniViewModel, QuestionariViewModel questionariViewModel, AnalisiViewModel analisiViewModel, VisiteMedicheViewModel visiteMedicheViewModel, SaccaSangueViewModel saccaSangueViewModel) {
            eventAggregator.Subscribe(this);

            DisplayName = "BloodBank";

            var saccaSangue = new SaccaSangue(null, GruppoSanguigno.AB_Neg, ComponenteEmatico.GlobuliRossi, DateTime.Now.AddDays(-3).AddHours(2));
            saccaSangueViewModel.Model = saccaSangue;

            Items.Add(new NavigationMenuItem("Donatori", "AccountMultiple", donatoriViewModel));
            Items.Add(new NavigationMenuItem("Donazioni", "Heart", donazioniViewModel));
            Items.Add(new NavigationMenuItem("Questionari", "Heart", questionariViewModel));
            Items.Add(new NavigationMenuItem("Analisi", "Heart", analisiViewModel));
            Items.Add(new NavigationMenuItem("Visite Mediche", "Hospital", visiteMedicheViewModel));
            Items.Add(new NavigationMenuItem("Sacche di Sangue", "Water", saccaSangueViewModel));
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

        #endregion NavMenu
    }
}