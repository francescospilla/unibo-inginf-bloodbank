using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Persone;
using BloodBank.ViewModel.ViewModels.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Donazioni
{

    [ImplementPropertyChanged]
    public class DonazioniViewModel : WorkspaceViewModel<Donazione, DonazioneViewModel>, IHandle<NuovaDonazioneEvent>
    {
        private readonly Func<NuovaDonazioneDialogViewModel> _dialogFactory;
        private readonly IDataService<Donazione, DonazioneViewModel> _donazioneDataService;

        public DonazioniViewModel(IEventAggregator eventAggregator, IDataService<Donazione, DonazioneViewModel> donazioneDataService, Func<DonazioneViewModel> viewModelFactory, Func<NuovaDonazioneDialogViewModel> dialogFactory) : base(eventAggregator, donazioneDataService, viewModelFactory)
        {
            _eventAggregator.Subscribe(this);
            _donazioneDataService = donazioneDataService;
            _dialogFactory = dialogFactory;
        }


        #region Actions

        public void OpenNewDialog()
        {
            var dialog = _dialogFactory();
            DialogEvent e = new DialogEvent(true, dialog);
            _eventAggregator.Publish(e);
        }

        public void Handle(NuovaDonazioneEvent message) {
            _eventAggregator.Publish(new DialogEvent(false, null));
            _donazioneDataService.AddModelAndCreatedViewModel(message.Donazione);
        }

        #endregion Actions


    }
}