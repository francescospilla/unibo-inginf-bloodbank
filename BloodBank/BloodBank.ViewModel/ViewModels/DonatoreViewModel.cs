using System;
using System.Collections.Generic;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class DonatoreViewModel : EditableViewModel<Donatore> {

        #region Constructors

        public DonatoreViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> dataService, IModelValidator<DonatoreViewModel> validator) : base(eventAggregator, dataService, validator) {
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
        public DateTime DataNascita { get; set; } = DateTime.Today;
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
        public bool Attivo { get; set; }

        #endregion Properties

        public IEnumerable<Sesso> SessoEnumerable { get; } = EnumExtensions.Values<Sesso>();
        public IEnumerable<GruppoSanguigno> GruppoSanguignoEnumerable { get; } = EnumExtensions.Values<GruppoSanguigno>();
        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();
        public IEnumerable<bool> AttivoEnumerable { get; } = new[] { true, false };

        #region Mappings

        protected override void SyncModelToViewModel() {
            Nome = Model.Nome;
            Cognome = Model.Cognome;
            Sesso = Model.Sesso;
            DataNascita = Model.DataNascita;
            CodiceFiscale = Model.CodiceFiscale;
            Indirizzo = Model.Indirizzo;
            Città = Model.Città;
            Stato = Model.Stato;
            CodicePostale = Model.CodicePostale;
            Telefono = Model.Telefono;
            Email = Model.Email;
            GruppoSanguigno = Model.GruppoSanguigno;
            Idoneità = Model.Idoneità;
            Attivo = Model.Attivo;
        }

        protected override Donatore CreateModelFromViewModel() {
            return new Donatore(new Contatto(Nome, Cognome, Sesso, DataNascita, CodiceFiscale, Indirizzo, Città, Stato, CodicePostale, Telefono, Email), GruppoSanguigno, Attivo);
        }

        protected override void SyncViewModelToModel() {
            Model.Indirizzo = Indirizzo;
            Model.Città = Città;
            Model.Stato = Stato;
            Model.CodicePostale = CodicePostale;
            Model.Telefono = Telefono;
            Model.Email = Email;
            Model.Attivo = Attivo;
        }

        #endregion Mappings
    }
}