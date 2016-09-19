using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Indagini;
using BloodBank.ViewModel.ViewModels.Persone;
using PropertyChanged;
using StructureMap;
using StructureMap.TypeRules;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    [AssociatedView("NuovaListaVociView")]
    public class NuovaListaVociViewModel<U> : Screen where U : ListaVoci {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _donatoreDataService;
        private readonly IDataService<ListaIndagini<U>, ListaIndaginiViewModel<U>> _listaIndaginiDataService;
        private readonly VoceViewModelFactory<U> _voceViewModelFactory;

        #region Constructors

        public NuovaListaVociViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> donatoreDataService, IDataService<ListaIndagini<U>, ListaIndaginiViewModel<U>> listaIndaginiDataService, VoceViewModelFactory<U> voceViewModelFactory) {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _listaIndaginiDataService = listaIndaginiDataService;
            _voceViewModelFactory = voceViewModelFactory;

            DonatoreEnumerable = _donatoreDataService.GetViewModels();
            ListaIndaginiEnumerable = _listaIndaginiDataService.GetViewModels();
        }

        #endregion

        #region Properties

        public DonatoreViewModel SelectedDonatore { get; set; }
        public ListaIndaginiViewModel<U> SelectedListaIndagini { get; set; }
        public IEnumerable<Voce<U>> GeneratedListVoci { get; set; }


        public bool CanMoveTo2ndPage => SelectedDonatore != null;
        public bool CanMoveTo3rdPage => SelectedListaIndagini != null;
        public bool CanMoveToLastPage => VociViewModelEnumerable != null && VociViewModelEnumerable.All(vm => vm.CanSave);
        public DateTime DataTest { get; set; }

        #endregion

        public IEnumerable<DonatoreViewModel> DonatoreEnumerable { get; }
        public IEnumerable<ListaIndaginiViewModel<U>> ListaIndaginiEnumerable { get; }
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
            DataTest = DateTime.Now;
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

            NuovaListaVociEvent<U> message = new NuovaListaVociEvent<U>(new ListaVoci<U>(SelectedDonatore.Model, SelectedListaIndagini.Model.Nome, DataTest, GeneratedListVoci));
            _eventAggregator.Publish(message);
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