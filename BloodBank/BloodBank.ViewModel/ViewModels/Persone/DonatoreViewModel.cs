﻿using System;
using System.Collections.Generic;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Persone {

    [ImplementPropertyChanged]
    public class DonatoreViewModel : EditableViewModel<Donatore> {

        #region Constructors

        public DonatoreViewModel(IEventAggregator eventAggregator, IDataService<Donatore> dataService, IModelValidator<DonatoreViewModel> validator) : base(eventAggregator, dataService, validator) {
        }

        #endregion Constructors

        #region Properties

        public new string DisplayName => IsInitialized ? NomeCognome : "Nuovo donatore";

        public string NomeCognome => Nome + " " + Cognome;
        public string CognomeNome => Cognome + " " + Nome;

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        [Searchable]
        public string Nome { get; set; }
        [Searchable]
        public string Cognome { get; set; }
        [Searchable]
        public Sesso Sesso { get; set; }
        [Searchable]
        public DateTime? DataNascita { get; set; } = DateTime.Today;
        [Searchable]
        public string CodiceFiscale { get; set; }
        [Searchable]
        public string Indirizzo { get; set; }
        [Searchable]
        public string Città { get; set; }
        [Searchable]
        public string Stato { get; set; }
        [Searchable]
        public string CodicePostale { get; set; }
        [Searchable]
        public string Telefono { get; set; }
        [Searchable]
        public string Email { get; set; }
        [Searchable]
        public GruppoSanguigno GruppoSanguigno { get; set; }
        [Searchable]
        public Idoneità? Idoneità { get; set; }
        [Searchable]
        public bool Attivo { get; set; }
        public DateTime? DataProssimaDonazioneConsentita { get; set; }

        #endregion Properties

        public IEnumerable<Sesso> SessoEnumerable { get; } = EnumExtensions.Values<Sesso>();
        public IEnumerable<GruppoSanguigno> GruppoSanguignoEnumerable { get; } = EnumExtensions.Values<GruppoSanguigno>();
        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();
        public IEnumerable<bool> AttivoEnumerable { get; } = new[] { true, false };

        #region Mappings

        protected override void SyncModelToViewModel() {
            Nome = Model.Contatto.Nome;
            Cognome = Model.Contatto.Cognome;
            Sesso = Model.Contatto.Sesso;
            DataNascita = Model.Contatto.DataNascita;
            CodiceFiscale = Model.Contatto.CodiceFiscale;
            Indirizzo = Model.Contatto.Indirizzo;
            Città = Model.Contatto.Città;
            Stato = Model.Contatto.Stato;
            CodicePostale = Model.Contatto.CodicePostale;
            Telefono = Model.Contatto.Telefono;
            Email = Model.Contatto.Email;
            GruppoSanguigno = Model.GruppoSanguigno;
            Idoneità = Model.Idoneità;
            Attivo = Model.Attivo;
            DataProssimaDonazioneConsentita = Model.DataProssimaDonazioneConsentita;
        }

        protected override Donatore CreateModelFromViewModel(out bool isModelAlreadyRegistered) {
            isModelAlreadyRegistered = false;
            return new Donatore(new Contatto(Nome, Cognome, Sesso, DataNascita.GetValueOrDefault(), CodiceFiscale, Indirizzo, Città, Stato, CodicePostale, Telefono, Email), GruppoSanguigno, Attivo);
        }

        protected override void PublishViewModel() {
            EventAggregator.Publish(new ViewModelCollectionChangedEvent<DonatoreViewModel>(this));
        }

        protected override void SyncViewModelToModel() {
            Model.Contatto.Indirizzo = Indirizzo;
            Model.Contatto.Città = Città;
            Model.Contatto.Stato = Stato;
            Model.Contatto.CodicePostale = CodicePostale;
            Model.Contatto.Telefono = Telefono;
            Model.Contatto.Email = Email;
            Model.Attivo = Attivo;
        }

        #endregion Mappings
    }
}