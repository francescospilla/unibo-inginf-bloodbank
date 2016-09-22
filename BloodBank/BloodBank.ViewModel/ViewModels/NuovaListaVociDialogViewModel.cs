using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Indagini;
using BloodBank.ViewModel.ViewModels.Persone;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    [AssociatedView("NuovaListaVociDialogView")]
    public class NuovaListaVociDialogViewModel<U> : Screen where U : ListaVoci {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore> _donatoreDataService;
        private readonly IDataService<ListaIndagini<U>> _listaIndaginiDataService;
        private readonly VoceViewModelFactory<U> _voceViewModelFactory;
        private readonly IListaVociFactory<U> _listaVociFactory; 

        #region Constructors

        public NuovaListaVociDialogViewModel(IEventAggregator eventAggregator, IDataService<Donatore> donatoreDataService, IDataService<ListaIndagini<U>> listaIndaginiDataService, VoceViewModelFactory<U> voceViewModelFactory, IListaVociFactory<U> listaVociFactory, DonatoreViewModel donatoreViewModel, ListaIndaginiViewModel<U> listaIndaginiViewModel) {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _listaIndaginiDataService = listaIndaginiDataService;
            _voceViewModelFactory = voceViewModelFactory;

            DonatoreViewModel = donatoreViewModel;
            ListaIndaginiViewModel = listaIndaginiViewModel;

            _listaVociFactory = listaVociFactory;
            
            DonatoreEnumerable = _donatoreDataService.GetModels().Where(m => m.Idoneità != Idoneità.NonIdoneo && m.Attivo);
            ListaIndaginiEnumerable = _listaIndaginiDataService.GetModels();
        }

        #endregion

        #region Properties

        private Donatore _selectedDonatore;
        public Donatore SelectedDonatore {
            get { return _selectedDonatore; }
            set { _selectedDonatore = value; DonatoreViewModel.Model = _selectedDonatore; }
        }

        private ListaIndagini<U> _selectedListaIndagini;
        public ListaIndagini<U> SelectedListaIndagini {
            get { return _selectedListaIndagini; }
            set { _selectedListaIndagini = value; ListaIndaginiViewModel.Model = _selectedListaIndagini; }
        }

        public IEnumerable<Voce<U>> GeneratedListVoci { get; set; }

        public DonatoreViewModel DonatoreViewModel { get; }
        public ListaIndaginiViewModel<U> ListaIndaginiViewModel { get; }

        public bool CanMoveTo2ndPage => SelectedDonatore != null;
        public bool CanMoveTo3rdPage => SelectedListaIndagini != null;
        public bool CanMoveToLastPage => VociViewModelEnumerable != null && VociViewModelEnumerable.All(vm => vm.CanSave);

        #region Data e Ora
        private DateTime _data = DateTime.Today;
        public DateTime Data {
            get { return _data; }
            set { _data = value.Date; }
        }

        private DateTime _dataOra = DateTime.Now;
        public DateTime DataOra {
            get { return _dataOra; }
            set { _dataOra = Data.Add(value.TimeOfDay); }
        }
        #endregion


        #endregion

        public IEnumerable<Donatore> DonatoreEnumerable { get; }
        public IEnumerable<ListaIndagini> ListaIndaginiEnumerable { get; }
        public IEnumerable<VoceViewModel> VociViewModelEnumerable { get; private set; }


        #region Actions

        public void OnChangeToNextPage() {
            switch (_stepCorrente) {
                case Step.SelezionaDonatore:
                    _stepCorrente = Step.SelezionaListaIndagini;
                    break;
                case Step.SelezionaListaIndagini:
                    VociViewModelEnumerable = _voceViewModelFactory.CreateViewModelsFrom(SelectedListaIndagini);
                    foreach (VoceViewModel vm in VociViewModelEnumerable) {
                        vm.ErrorsChanged += (sender, args) => NotifyOfPropertyChange(() => CanMoveToLastPage);
                    }
                    _stepCorrente = Step.CompilaListaIndagini;
                    break;
                case Step.CompilaListaIndagini:
                    GeneratedListVoci = _voceViewModelFactory.GetModelsFromViewModels(VociViewModelEnumerable);
                    _stepCorrente = Step.Riepilogo;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public void OnChangeToPreviousPage() {
            switch (_stepCorrente) {
                case Step.SelezionaListaIndagini:
                    _stepCorrente = Step.SelezionaDonatore;
                    break;
                case Step.CompilaListaIndagini:
                    _stepCorrente = Step.SelezionaListaIndagini;
                    break;
                case Step.Riepilogo:
                    _stepCorrente = Step.CompilaListaIndagini;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Finish() {
            if (_stepCorrente != Step.Riepilogo)
                throw new InvalidOperationException("stepCorrente != Step.Riepilogo");

            _listaVociFactory.CreateModel(SelectedDonatore, SelectedListaIndagini.Nome, DataOra, GeneratedListVoci);
            _eventAggregator.Publish(new DialogEvent(false, null));

        }

        public void Cancel() {
            _eventAggregator.Publish(new DialogEvent(false, null));
        }

        #endregion

        #region Steps 

        private Step _stepCorrente = Step.SelezionaDonatore;

        private enum Step {
            SelezionaDonatore,
            SelezionaListaIndagini,
            CompilaListaIndagini,
            Riepilogo
        }

        #endregion
    }
}