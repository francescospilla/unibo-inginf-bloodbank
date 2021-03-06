﻿using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;
using System;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.ViewModels.Donazioni;
using BloodBank.ViewModel.ViewModels.Indagini;
using BloodBank.ViewModel.ViewModels.Persone;
using BloodBank.ViewModel.ViewModels.Sangue;
using BloodBank.ViewModel.ViewModels.Tests;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class ShellViewModel : Conductor<NavigationMenuItem>.Collection.OneActive, IHandle<NavMenuEvent>, IHandle<DialogEvent> {

        public ShellViewModel(IEventAggregator eventAggregator, DonatoriViewModel donatoriViewModel, DonazioniViewModel donazioniViewModel, SaccheSangueViewModel saccheSangueViewModel, ListeIndaginiViewModel<Analisi> listeIndaginiAnalisIndaginiViewModel, ListeIndaginiViewModel<Questionario> listeIndaginiQuestionarioViewModel, VisiteMedicheViewModel visiteMedicheViewModel, AnalisiViewModel analisiViewModel, QuestionariViewModel questionariViewModel, IndaginiViewModel indaginiViewModel) {

            eventAggregator.Subscribe(this);

            DisplayName = "BloodBank";

            AddNewNavigationMenuItem(donatoriViewModel, "Donatori", "AccountMultiple");
            AddNewNavigationMenuItem(donazioniViewModel, "Donazioni", "Heart");
            AddNewNavigationMenuItem(saccheSangueViewModel, "Sacche di Sangue", "Water");
            AddNewNavigationMenuItem(questionariViewModel, "Questionari", "Book");
            AddNewNavigationMenuItem(analisiViewModel, "Analisi", "Hospital");
            AddNewNavigationMenuItem(visiteMedicheViewModel, "Visite Mediche", "Stethoscope");
            AddNewNavigationMenuItem(indaginiViewModel, "Configura Indagini", "Settings");
            AddNewNavigationMenuItem(listeIndaginiAnalisIndaginiViewModel, "Configura Analisi", "Settings");
            AddNewNavigationMenuItem(listeIndaginiQuestionarioViewModel, "Configura Questionari", "Settings");

        }
        
        #region NavMenu

        private void AddNewNavigationMenuItem(IScreen viewModel, string name, string icon) {
            viewModel.DisplayName = name;
            Items.Add(new NavigationMenuItem(name, icon, viewModel));
        }

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

        #region Dialog
        public bool IsDialogOpen { get; set; }
        public IScreen DialogContent { get; private set; }

        public void Handle(DialogEvent message)
        {
            DialogContent = message.DialogContent;
            IsDialogOpen = message.IsOpen;
        }
        #endregion Dialog
    }
}