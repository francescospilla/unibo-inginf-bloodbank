using System;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Indagini {

    [ImplementPropertyChanged]
    [AssociatedView("ListeIndaginiView")]
    public class ListeIndaginiViewModel<U> : WorkspaceViewModel<ListaIndagini<U>, ListaIndaginiViewModel<U>> where U : ListaVoci {

        public ListeIndaginiViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<U>, ListaIndaginiViewModel<U>> dataService, Func<ListaIndaginiViewModel<U>> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory) {
        }


    }
}