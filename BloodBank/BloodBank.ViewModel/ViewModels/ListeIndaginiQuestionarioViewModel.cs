using System;
using System.Linq;
using BloodBank.Model.Indagini;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class ListeIndaginiQuestionarioViewModel : WorkspaceViewModel<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> {

        public ListeIndaginiQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> dataService, Func<ListaIndaginiQuestionarioViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory) {
        }

    }
}