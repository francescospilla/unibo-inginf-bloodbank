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
    public class DonazioniViewModel : WorkspaceViewModel<Donazione, DonazioneViewModel>, IHandle<SaveDonazioneEvent>
    {
        private readonly IDataService<Donatore, DonatoreViewModel> _donatoreDataService;
        private readonly IDataService<VisitaMedica, VisitaMedicaViewModel> _visitaMedicaDataService;
        private readonly IDataService<ListaVoci<Questionario>, ListaVociQuestionarioViewModel> _listaVociQuestionarioDataService;
        private readonly IDataService<ListaVoci<Analisi>, ListaVociAnalisiViewModel> _listaVociAnalisiDataService;
        private IDataService<Donazione, DonazioneViewModel> _donazioneDataService;

        public DonazioniViewModel(IEventAggregator eventAggregator, IDataService<Donazione, DonazioneViewModel> donazioneDataService, IDataService<Donatore, DonatoreViewModel> donatoreDataService, IDataService<ListaVoci<Questionario>, ListaVociQuestionarioViewModel> listaVociQuestionarioDataService,
            IDataService<ListaVoci<Analisi>, ListaVociAnalisiViewModel> listaVociAnalisiDataService,
            IDataService<VisitaMedica, VisitaMedicaViewModel> visitaMedicaDataService, Func<DonazioneViewModel> viewModelFactory) : base(eventAggregator, donazioneDataService, viewModelFactory)
        {
            _eventAggregator.Subscribe(this);
            _donazioneDataService = donazioneDataService;
            _donatoreDataService = donatoreDataService;
            _listaVociQuestionarioDataService = listaVociQuestionarioDataService;
            _listaVociAnalisiDataService = listaVociAnalisiDataService;
            _visitaMedicaDataService = visitaMedicaDataService;
        }


        #region Actions

        public void OpenNewDialog()
        {
            var dialog = new NuovaDonazioneDialogViewModel(_eventAggregator, _donatoreDataService,
                _listaVociQuestionarioDataService, _listaVociAnalisiDataService, _visitaMedicaDataService);
            DialogEvent e = new DialogEvent(true, dialog);
            _eventAggregator.Publish(e);
        }

        #endregion Actions

        public void Handle(SaveDonazioneEvent message)
        {
            _eventAggregator.Publish(new DialogEvent(false, null));
            _donazioneDataService.AddModelAndCreatedViewModel(message.Donazione);
        }
    }
}