using System;
using System.Collections.Generic;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using Stylet;
using PropertyChanged;

namespace BloodBank.ViewModel.ViewModels
{

    [ImplementPropertyChanged]
    public class ListaVociViewModel<U> : ViewModel<ListaVoci<U>> where U : ListaVoci
    {
        public ListaVociViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public Donatore Donatore { get; set; }
        public DateTime Data { get; set; }
        public string DescrizioneBreve { get; set; }
        public Idoneità Idoneità { get; set; }
        public IEnumerable<Voce> Voci { get; set; }

        protected override void SyncModelToViewModel()
        {
            Donatore = Model.Donatore;
            Data = Model.Data;
            DescrizioneBreve = Model.DescrizioneBreve;
            Idoneità = Model.Idoneità;
            Voci = Model.Voci;
        }
    }
}
