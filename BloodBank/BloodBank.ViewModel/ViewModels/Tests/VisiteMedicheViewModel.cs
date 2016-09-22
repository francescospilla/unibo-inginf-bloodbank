using System;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests
{
    [ImplementPropertyChanged]
    public class VisiteMedicheViewModel : TabWorkspaceViewModel<VisitaMedica, VisitaMedicaViewModel> {

        public VisiteMedicheViewModel(IEventAggregator eventAggregator, IDataService<VisitaMedica> dataService, Func<VisitaMedicaViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }
}
