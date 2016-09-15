using System;
using BloodBank.Model.Models.Sangue;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Sangue
{
    public class SaccheSangueViewModel : TabWorkspaceViewModel<SaccaSangue, SaccaSangueViewModel>
    {
        public SaccheSangueViewModel(IEventAggregator eventAggregator, IDataService<SaccaSangue, SaccaSangueViewModel> dataService, Func<SaccaSangueViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }
}
