using System;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Persone {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : TabWorkspaceViewModel<Donatore, DonatoreViewModel> {

        public DonatoriViewModel(IEventAggregator eventAggregator, IDataService<Donatore> dataService, Func<DonatoreViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory) {
        }
    }
}