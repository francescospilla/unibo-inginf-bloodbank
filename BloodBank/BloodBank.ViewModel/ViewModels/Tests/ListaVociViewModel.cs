using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels.Tests
{

    [ImplementPropertyChanged]
    [AssociatedView("ListaVociView")]
    public class ListaVociViewModel<U> : ViewModel<U> where U : ListaVoci
    {
        public ListaVociViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }



        public string DataDonatore => Data.ToShortDateString() + " - " + Donatore.Nome + " " + Donatore.Cognome;

        public new string DisplayName => IsInitialized ? DataDonatore : "Nuovo test";

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        [Searchable]
		
        #region Properties

        public Donatore Donatore { get; set; }
        public string DescrizioneBreve { get; set; }
        public Idoneità Idoneità { get; set; }
        public IEnumerable<Voce> Voci { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataOra { get; set; }

        public string Type => typeof(U).ToString().Split('.').Last();
        
        #endregion Properties

        protected override void SyncModelToViewModel()
        {
            Donatore = Model.Donatore;
            Data = Model.Data;
            DataOra = Model.Data;
            DescrizioneBreve = Model.DescrizioneBreve;
            Idoneità = Model.Idoneità;
            Voci = Model.Voci;
        }
    }
}
