using System;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.Validation.Indagini;
using PropertyChanged;
using Stylet;
using Stylet.FluentValidation;

namespace BloodBank.ViewModel.ViewModels.Tests {

    [ImplementPropertyChanged]
    public class ListeIndaginiQuestionarioViewModel : WorkspaceViewModel<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> {

        public ListeIndaginiQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> donatoreDataService, Func<ListaIndaginiQuestionarioViewModel> viewModelFactory) : base(eventAggregator, donatoreDataService, viewModelFactory) {
        }


    }
}