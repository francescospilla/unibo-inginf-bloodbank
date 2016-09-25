using System;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Sangue
{
    public class SaccheSangueViewModel : WorkspaceViewModel<SaccaSangue, SaccaSangueViewModel>
    {
        public SaccheSangueViewModel(IEventAggregator eventAggregator, IDataService<SaccaSangue> dataService, Func<SaccaSangueViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }
}
