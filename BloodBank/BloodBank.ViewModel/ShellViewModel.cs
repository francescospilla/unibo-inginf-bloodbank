﻿using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;
using System;
using System.Collections.Generic;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.ViewModels;
using BloodBank.ViewModel.ViewModels.Donazioni;
using BloodBank.ViewModel.ViewModels.Persone;
using BloodBank.ViewModel.ViewModels.Sangue;
using BloodBank.ViewModel.ViewModels.Tests;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class ShellViewModel : Conductor<NavigationMenuItem>.Collection.OneActive, IHandle<NavMenuEvent>, IHandle<DialogEvent> {

        public ShellViewModel(IEventAggregator eventAggregator, DonatoriViewModel donatoriViewModel, DonazioniViewModel donazioniViewModel, SaccheSangueViewModel saccheSangueViewModel, ListeIndaginiQuestionarioViewModel listeIndaginiQuestionarioViewModel, VisiteMedicheViewModel visiteMedicheViewModel, ListeVociAnalisiViewModel listeVociAnalisiViewModel, ListeVociQuestionarioViewModel listeVociQuestionarioViewModel, IndaginiViewModel indaginiViewModel, NewListaVociQuestionarioViewModel newListaVociViewModel, NewDonazioneViewModel newDonazioneViewModel) {

            eventAggregator.Subscribe(this);

            DisplayName = "BloodBank";

            List<Voce> voci = new List<Voce>(){
                new Voce<Questionario, bool>(new IndagineBoolean<Questionario>("Domanda 1", Idoneità.NonIdoneo, true), true),
                 new Voce<Questionario, int>(new IndagineRange<Questionario, int>("Domanda 10", Idoneità.NonIdoneo, 0, 10), -1)
            };

            Items.Add(new NavigationMenuItem("Donatori", "AccountMultiple", donatoriViewModel));
            Items.Add(new NavigationMenuItem("Donazioni", "Heart", donazioniViewModel));
            Items.Add(new NavigationMenuItem("Analisi", "Hospital", listeVociAnalisiViewModel));
            Items.Add(new NavigationMenuItem("Questionari", "Book", listeVociQuestionarioViewModel));
            Items.Add(new NavigationMenuItem("Sacche di Sangue", "Water", saccheSangueViewModel));
            Items.Add(new NavigationMenuItem("Questionari", "Pencil", listeIndaginiQuestionarioViewModel));
            Items.Add(new NavigationMenuItem("Visite Mediche", "Stethoscope", visiteMedicheViewModel));            
            Items.Add(new NavigationMenuItem("Indagini", "Help", indaginiViewModel));
            Items.Add(new NavigationMenuItem("Nuovo Questionario", "Help", newListaVociViewModel));
            Items.Add(new NavigationMenuItem("Nuova Donazione", "Skull", newDonazioneViewModel));
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