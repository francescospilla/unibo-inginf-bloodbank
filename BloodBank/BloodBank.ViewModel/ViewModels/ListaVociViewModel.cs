using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Extensions;
using BloodBank.Model;
using BloodBank.Model.Donatori;
using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using Stylet;
using PropertyChanged;

namespace BloodBank.ViewModel.ViewModels
{

    [ImplementPropertyChanged]
    public class ListaVociViewModel : ViewModel<ListaVoci>
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
