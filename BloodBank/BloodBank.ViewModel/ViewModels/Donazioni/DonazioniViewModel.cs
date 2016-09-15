using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class DonazioniViewModel : TabWorkspaceViewModel<Donazione, DonazioneViewModel>
    {
        public DonazioniViewModel(IEventAggregator eventAggregator, IDataService<Donazione, DonazioneViewModel> dataService, Func<DonazioneViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }
}