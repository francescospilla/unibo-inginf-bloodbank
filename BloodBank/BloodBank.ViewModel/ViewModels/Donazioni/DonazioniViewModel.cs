using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Donazioni
{

    [ImplementPropertyChanged]
    public class DonazioniViewModel : WorkspaceViewModel<Donazione, DonazioneViewModel>
    {
        private readonly Func<NuovaDonazioneDialogViewModel> _dialogFactory;

        public DonazioniViewModel(IEventAggregator eventAggregator, IDataService<Donazione> donazioneDataService, Func<DonazioneViewModel> viewModelFactory, Func<NuovaDonazioneDialogViewModel> dialogFactory) : base(eventAggregator, donazioneDataService, viewModelFactory)
        {
            EventAggregator.Subscribe(this);
            _dialogFactory = dialogFactory;
        }


        #region Actions

        public void OpenNewDialog()
        {
            var dialog = _dialogFactory();
            DialogEvent e = new DialogEvent(true, dialog);
            EventAggregator.Publish(e);
        }
        
        #endregion Actions


    }
}