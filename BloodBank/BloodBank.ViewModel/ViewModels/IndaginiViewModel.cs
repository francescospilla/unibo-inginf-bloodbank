using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class IndaginiViewModel<U> : Conductor<Indagine<U>>.Collection.AllActive where U : ListaVoci {
        private IEventAggregator _eventAggregator;
        private IDataService<Indagine<U>> _dataService;

        public IndaginiViewModel(IEventAggregator eventAggregator, IDataService<Indagine<U>> dataService) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;

            DisplayName = typeof(Indagine).Name;

            Items.AddRange(_dataService.GetModels());
        }

    }
}
