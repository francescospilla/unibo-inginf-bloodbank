using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Persone;
using BloodBank.ViewModel.ViewModels.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {
    [ImplementPropertyChanged]
    public class NuovaDonazioneDialogViewModel : Screen {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore> _donatoreDataService;
        private readonly IDataService<VisitaMedica> _visitaMedicaDataService;
        private readonly IDataService<Questionario> _listaVociQuestionarioDataService;
        private readonly IDataService<Analisi> _listaVociAnalisiDataService;
        private readonly IDonazioneFactory _donazioneFactory;

        public NuovaDonazioneDialogViewModel(IEventAggregator eventAggregator,
            IDataService<Donatore> donatoreDataService,
            IDataService<Questionario> listaVociQuestionarioDataService,
            IDataService<Analisi> listaVociAnalisiDataService,
            IDataService<VisitaMedica> visitaMedicaDataService, IDonazioneFactory donazioneFactory, DonatoreViewModel donatoreViewModel, VisitaMedicaViewModel visitaMedicaViewModel, ListaVociViewModel<Questionario> questionarioViewModel, ListaVociViewModel<Analisi> analisiViewModel) {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _listaVociQuestionarioDataService = listaVociQuestionarioDataService;
            _listaVociAnalisiDataService = listaVociAnalisiDataService;
            _visitaMedicaDataService = visitaMedicaDataService;

            DonatoreViewModel = donatoreViewModel;
            VisitaMedicaViewModel = visitaMedicaViewModel;
            QuestionarioViewModel = questionarioViewModel;
            AnalisiViewModel = analisiViewModel;

            _donazioneFactory = donazioneFactory;

            DonatoreEnumerable = _donatoreDataService.GetModels().Where(m => m.Idoneità == Idoneità.Idoneo && m.Attivo && (m.DataProssimaDonazioneConsentita == null || m.DataProssimaDonazioneConsentita <= DateTime.Today));
        }

        #region Properties

        private Donatore _selectedDonatore;
        public Donatore SelectedDonatore {
            get { return _selectedDonatore; }
            set { _selectedDonatore = value; DonatoreViewModel.Model = SelectedDonatore; }
        }

        private Questionario _selectedListaVociQuestionario;
        public Questionario SelectedListaVociQuestionario {
            get { return _selectedListaVociQuestionario; }
            set { _selectedListaVociQuestionario = value; QuestionarioViewModel.Model = SelectedListaVociQuestionario; }
        }

        private Analisi _selectedListaVociAnalisi;
        public Analisi SelectedListaVociAnalisi {
            get { return _selectedListaVociAnalisi; }
            set { _selectedListaVociAnalisi = value; AnalisiViewModel.Model = SelectedListaVociAnalisi; }
        }

        private VisitaMedica _selectedVisitaMedica;
        public VisitaMedica SelectedVisitaMedica {
            get { return _selectedVisitaMedica; }
            set { _selectedVisitaMedica = value; VisitaMedicaViewModel.Model = SelectedVisitaMedica; }
        }

        public TipoDonazione SelectedTipoDonazione { get; set; }
        public DateTime DataDonazione { get; set; }
        
        public DonatoreViewModel DonatoreViewModel { get; }
        public VisitaMedicaViewModel VisitaMedicaViewModel { get; }
        public ListaVociViewModel<Questionario> QuestionarioViewModel { get; }
        public ListaVociViewModel<Analisi> AnalisiViewModel { get; }

        public bool CanMoveTo2ndPage => SelectedDonatore != null;
        public bool CanMoveTo3rdPage => SelectedListaVociQuestionario != null;
        public bool CanMoveTo4thPage => SelectedListaVociAnalisi != null;
        public bool CanMoveTo5thPage => SelectedVisitaMedica != null;
        public bool CanMoveToLastPage => SelectedTipoDonazione != null;

        #endregion

        public IEnumerable<Donatore> DonatoreEnumerable { get; }
        public IEnumerable<Questionario> ListaVociQuestionarioEnumerable { get; private set; }
        public IEnumerable<Analisi> ListaVociAnalisiEnumerable { get; private set; }
        public IEnumerable<VisitaMedica> VisitaMedicaEnumerable { get; private set; }
        public IEnumerable<TipoDonazione> TipoDonazioneEnumerable => TipoDonazione.Values;

        #region Actions

        public void OnChangeToNextPage(object sender, EventArgs e) {
            if (SelectedDonatore == null)
                return;
            ListaVociAnalisiEnumerable = _listaVociAnalisiDataService.GetModels().Where(m => m.Donatore.Equals(SelectedDonatore) && m.Data.Date.Equals(DateTime.Today) && m.Idoneità == Idoneità.Idoneo);
            ListaVociQuestionarioEnumerable = _listaVociQuestionarioDataService.GetModels().Where(m => m.Donatore.Equals(SelectedDonatore) && m.Data.Date.Equals(DateTime.Today) && m.Idoneità == Idoneità.Idoneo);
            VisitaMedicaEnumerable = _visitaMedicaDataService.GetModels().Where(m => m.Donatore.Equals(SelectedDonatore) && m.Data.Date.Equals(DateTime.Today) && m.Idoneità == Idoneità.Idoneo);
            DataDonazione = DateTime.Now;
        }

        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void Finish() {
            _donazioneFactory.CreateModel(SelectedDonatore, SelectedTipoDonazione, DataDonazione, SelectedVisitaMedica, SelectedListaVociAnalisi, SelectedListaVociQuestionario);
            _eventAggregator.Publish(new DialogEvent(false, null));
        }

        public void Cancel() {
            _eventAggregator.Publish(new DialogEvent(false, null));
        }

        #endregion

    }



}
