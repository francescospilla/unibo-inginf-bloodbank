using System;
using BloodBank.Model.Models.Persone;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : TabWorkspaceViewModel<Donatore, DonatoreViewModel> {

        public DonatoriViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> dataService, Func<DonatoreViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory) {
        }
    }
}