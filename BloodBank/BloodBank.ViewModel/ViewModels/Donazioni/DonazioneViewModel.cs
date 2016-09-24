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

        public new string DisplayName => IsInitialized ? DonazioneNomeCognome : "Nuova donazione";

        public string DonazioneNomeCognome => "Donazione " +  Donatore.Contatto.Nome + " " + Donatore.Contatto.Cognome;
        public string CognomeNome => Donatore.Contatto.Cognome + " " + Donatore.Contatto.Nome;

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));
        
        [Searchable]
        public Donatore Donatore { get; set; }
        public TipoDonazione TipoDonazione { get; set; }
        public VisitaMedica VisitaMedica { get; set; }
        public Analisi Analisi { get; set; }
        public Questionario Questionario { get; set; }
        public IEnumerable<SaccaSangue> SaccheSangue { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataOra { get; set; }

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
