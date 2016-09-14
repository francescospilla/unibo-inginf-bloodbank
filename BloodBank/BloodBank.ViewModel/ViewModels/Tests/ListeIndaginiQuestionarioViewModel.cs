using System;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests {

    [ImplementPropertyChanged]
    public class ListeIndaginiQuestionarioViewModel : WorkspaceViewModel<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> {

        public ListeIndaginiQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> dataService, Func<ListaIndaginiQuestionarioViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory) {
        }

    }
}