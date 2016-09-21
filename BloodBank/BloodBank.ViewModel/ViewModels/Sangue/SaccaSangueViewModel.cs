using System;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Sangue;
using BloodBank.ViewModel.Components;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Sangue {

    [ImplementPropertyChanged]
    public class SaccaSangueViewModel : ViewModel<SaccaSangue> {

        #region Constructors
        public SaccaSangueViewModel(IEventAggregator eventAggregator) : base(eventAggregator) {
        }
        #endregion

        #region Properties

        public new string DisplayName => IsInitialized ? IdSacca : "Nuova Sacca";
        public string CompEmGruppoSanguigno => Componente + " " + Gruppo;

        public string IdSacca => Id.ToString();

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        #region Data e Ora
        private DateTime _data = DateTime.Today;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value.Date; }
        }

        private DateTime _dataOra = DateTime.Now;
        public DateTime DataOra
        {
            get { return _dataOra; }
            set { _dataOra = Data.Add(value.TimeOfDay); }
        }
        #endregion

        [Searchable]
        public Guid Id { get; set; }
        [Searchable]
        public Donazione Donazione { get; set; }
        [Searchable]
        public DateTime DataScadenza { get; set; }
        [Searchable]
        public GruppoSanguigno Gruppo { get; set; }
        [Searchable]
        public ComponenteEmatico Componente { get; set; }
        public bool Disponibile { get; set; }
        public bool Scaduta { get; set; }
        [Searchable]
        public string DisponibileString => !Disponibile ? "Non Disponibile" : Scaduta ? "Scaduta" : "Disponibile";

        #endregion
        

        #region Mappings

        protected override void SyncModelToViewModel() {
            Id = Model.Id;
            Donazione = Model.Donazione;
            Data = Model.DataPrelievo;
            DataOra = Model.DataPrelievo;
            DataScadenza = Model.DataScadenza;
            Gruppo = Model.Gruppo;
            Componente = Model.Componente;
            Disponibile = Model.Disponibile;
            Scaduta = Model.Scaduta;
        }

        #endregion

        #region Actions

        public bool CanPrelevaSacca => Disponibile && !Scaduta;
        public void PrelevaSacca() {
            Model.Preleva();
        }

        #endregion
    }
}
