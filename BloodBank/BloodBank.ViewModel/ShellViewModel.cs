using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;
using System;
using System.Collections.Generic;
using BloodBank.Model;
using BloodBank.Model.Donatori;
using BloodBank.Model.Indagini;
using BloodBank.Model.Indagini.Tipi;
using BloodBank.Model.Sangue;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.ViewModels;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class ShellViewModel : Conductor<NavigationMenuItem>.Collection.OneActive, IHandle<NavMenuEvent> {

        public ShellViewModel(IEventAggregator eventAggregator, DonatoriViewModel donatoriViewModel, DonazioniViewModel donazioniViewModel, ListeIndaginiQuestionarioViewModel listeIndaginiQuestionarioViewModel, VisiteMedicheViewModel visiteMedicheViewModel, ListaVociViewModel listaVociViewModel) {
            eventAggregator.Subscribe(this);

            DisplayName = "BloodBank";

            List<Voce> voci = new List<Voce>(){
                new Voce<Questionario, bool>(new IndagineBoolean<Questionario>("Domanda 1", Idoneità.NonIdoneo, true), true),
                 new Voce<Questionario, int>(new IndagineRange<Questionario, int>("Domanda 10", Idoneità.NonIdoneo, 0, 10), -1)
            };
            Analisi analisi = new Analisi(new Donatore(new Contatto("Pasquale", "Cafiero", Sesso.Maschio, new DateTime(1971, 12, 24), "DQCSRN36T14A704A", "Via Capo di Monte, 33", "Bologna", "Italia", "12345"), GruppoSanguigno.AB_Neg, true), "Descrizione brevissima delle analisi", DateTime.Today, voci);

            listaVociViewModel.Model = analisi;

            Items.Add(new NavigationMenuItem("Donatori", "AccountMultiple", donatoriViewModel));
            Items.Add(new NavigationMenuItem("Donazioni", "Heart", donazioniViewModel));
            Items.Add(new NavigationMenuItem("Questionari", "Heart", listeIndaginiQuestionarioViewModel));
            Items.Add(new NavigationMenuItem("Visite Mediche", "Hospital", visiteMedicheViewModel));
            Items.Add(new NavigationMenuItem("Tests", "Help", listaVociViewModel));
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