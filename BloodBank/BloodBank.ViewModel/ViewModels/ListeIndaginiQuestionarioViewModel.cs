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

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class ListeIndaginiQuestionarioViewModel : WorkspaceViewModel<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> {

        public ListeIndaginiQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> dataService, Func<ListaIndaginiQuestionarioViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory) {
        }

        #region NuovaIndagineButton

        public void OpenNewIndagineBooleanDialog()
        {
            OpenDialogEvent e = new OpenDialogEvent(new NuovaIndagineBooleanDialogViewModel(_eventAggregator, new FluentModelValidator<NuovaIndagineBooleanDialogViewModel>(new NuovaIndagineBooleanValidator())));
            _eventAggregator.PublishOnUIThread(e);
        }

        public void OpenNewIndagineRangeDialog()
        {

        }
        
        #endregion NuovaIndagineButton
    }
}