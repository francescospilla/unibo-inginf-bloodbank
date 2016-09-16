using System;
using System.Collections.Generic;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Donazioni
{
    [ImplementPropertyChanged]
    public class DonazioneViewModel : ViewModel<Donazione>
    {
        public DonazioneViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        #region Properties

        public new string DisplayName => IsInitialized ? DonazioneNomeCognome : "Donazioni...";

        public string DonazioneNomeCognome => "Donazione " +  Donatore.Nome + " " + Donatore.Cognome;
        public string CognomeNome => Donatore.Cognome + " " + Donatore.Nome;

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        #region Data e Ora
        private DateTime _data = DateTime.Now;
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
        public Donatore Donatore { get; set; }
        public TipoDonazione TipoDonazione { get; set; }
        public VisitaMedica VisitaMedica { get; set; }
        public Analisi Analisi { get; set; }
        public Questionario Questionario { get; set; }
        public List<SaccaSangue> SaccheSangue { get; set; }

        #endregion Properties

        protected override void SyncModelToViewModel()
        {
            Donatore = Model.Donatore;
            Data = Model.Data;
            DataOra = Model.Data;
            TipoDonazione = Model.TipoDonazione;
            VisitaMedica = Model.VisitaMedica;
            Analisi = Model.Analisi;
            Questionario = Model.Questionario;
            SaccheSangue = Model.SaccheSangue;

        }
    }
}
