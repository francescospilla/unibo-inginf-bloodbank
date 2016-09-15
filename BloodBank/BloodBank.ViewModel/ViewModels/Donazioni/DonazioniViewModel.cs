using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Donazioni {

    [ImplementPropertyChanged]
    public class DonazioniViewModel : WorkspaceViewModel<Donazione, DonazioneViewModel>
    {
        public DonazioniViewModel(IEventAggregator eventAggregator, IDataService<Donazione, DonazioneViewModel> dataService, Func<DonazioneViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }
}