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

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));
        
        [Searchable]
        public Donatore Donatore { get; set; }
        [Searchable]
        public TipoDonazione TipoDonazione { get; set; }
        public VisitaMedica VisitaMedica { get; set; }
        public Analisi Analisi { get; set; }
        public Questionario Questionario { get; set; }
        public IEnumerable<SaccaSangue> SaccheSangue { get; set; }

        [Searchable]
        public GruppoSanguigno GruppoSanguigno => Donatore.GruppoSanguigno;
        [Searchable]
        public DateTime Data { get; set; }
        public DateTime DataOra { get; set; }

        #endregion Properties

        protected override void SyncModelToViewModel()
        {
            Donatore = Model.Donatore;
            Data = Model.Data.Date;
            DataOra = Model.Data;
            TipoDonazione = Model.TipoDonazione;
            VisitaMedica = Model.VisitaMedica;
            Analisi = Model.Analisi;
            Questionario = Model.Questionario;
            SaccheSangue = Model.SaccheSangue;

        }
    }
}
