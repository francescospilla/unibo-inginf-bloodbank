using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class VisiteMedicheViewModel : TabWorkspaceViewModel<VisitaMedica, VisitaMedicaViewModel> {

        public VisiteMedicheViewModel(IEventAggregator eventAggregator, IDataService<VisitaMedica, VisitaMedicaViewModel> dataService, Func<VisitaMedicaViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }
}
