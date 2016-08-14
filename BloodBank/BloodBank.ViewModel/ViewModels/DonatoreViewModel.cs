using BloodBank.Core.Extensions;
using BloodBank.Model;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;
using System;
using System.Collections.Generic;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class DonatoreViewModel : EditableViewModel<Donatore>, IDonatore {

        #region Constructors

        public DonatoreViewModel(IEventAggregator eventAggregator, DataService<Donatore, DonatoreViewModel> dataService, IModelValidator<IDonatore> validator) : base(eventAggregator, dataService, validator) {
        }

        #endregion Constructors

        #region Properties

        public new string DisplayName => IsInitialized ? NomeCognome : "Nuovo donatore";

        public string NomeCognome => Nome + " " + Cognome;
        public string CognomeNome => Cognome + " " + Nome;

        // TODO: Aggiustare?
        public string StringaRicerca => DisplayName;

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Sesso Sesso { get; set; }
        public DateTime DataNascita { get; set; } = DateTime.Today;
        public string CodiceFiscale { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public string Stato { get; set; }
        public string CodicePostale { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public GruppoSanguigno GruppoSanguigno { get; set; }
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