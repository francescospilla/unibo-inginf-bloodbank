using System;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.Validation.Indagini;
using BloodBank.ViewModel.ViewModels.Indagini;
using PropertyChanged;
using Stylet;
using Stylet.FluentValidation;

namespace BloodBank.ViewModel.ViewModels.Tests {

    [ImplementPropertyChanged]
    [AssociatedView("ListeIndaginiView")]
    public class ListeIndaginiViewModel<U> : WorkspaceViewModel<ListaIndagini<U>, ListaIndaginiViewModel<U>> where U : ListaVoci {

        public ListeIndaginiViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<U>, ListaIndaginiViewModel<U>> dataService, Func<ListaIndaginiViewModel<U>> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory) {
        }


    }
}