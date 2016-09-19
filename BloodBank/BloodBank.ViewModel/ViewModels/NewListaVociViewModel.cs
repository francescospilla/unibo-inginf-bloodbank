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
using BloodBank.ViewModel.Components;
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
    [AssociatedView("NewListaVociView")]
    public class NewListaVociViewModel<U> : Screen where U : ListaVoci {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _donatoreDataService;
        private readonly IDataService<ListaIndagini<U>, ListaIndaginiViewModel<U>> _listaIndaginiDataService;
        private readonly IModelValidator<VoceViewModel> _voceValidator;
        
        #region Constructors

        public NewListaVociViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> donatoreDataService, IDataService<ListaIndagini<U>, ListaIndaginiViewModel<U>> listaIndaginiDataService, IModelValidator<VoceViewModel> voceValidator) {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _listaIndaginiDataService = listaIndaginiDataService;
            _voceValidator = voceValidator;

            DonatoreEnumerable = _donatoreDataService.GetViewModels();
            ListaIndaginiEnumerable = _listaIndaginiDataService.GetViewModels();
        }

        #endregion

        #region Properties

        public DonatoreViewModel SelectedDonatore { get; set; }
        public ListaIndaginiViewModel<U> SelectedListaIndagini { get; set; }

        #endregion

        public IEnumerable<DonatoreViewModel> DonatoreEnumerable { get; }
        public IEnumerable<ListaIndaginiViewModel<U>> ListaIndaginiEnumerable { get; }
        public IEnumerable<VoceViewModel<U>> VociViewModelEnumerable { get; private set; }

        public void OnChangeToNextPage() {
            if (SelectedListaIndagini != null) {
                VociViewModelEnumerable = CreateViewModelsFrom(SelectedListaIndagini);
            }
        }

        private IEnumerable<VoceViewModel<U>> CreateViewModelsFrom(ListaIndaginiViewModel<U> selectedListaIndagini) {
            return selectedListaIndagini.Model.Cast<Indagine<U>>().Select(CreateViewModelFrom).ToList();
        }

        private VoceViewModel<U> CreateViewModelFrom(Indagine<U> indagine) {

            Type[] genericTypeArguments = indagine.GetType().BaseType.GenericTypeArguments;
            Type viewModelType = typeof (VoceViewModel<,>).MakeGenericType(genericTypeArguments);
            object viewModel = Activator.CreateInstance(viewModelType, _eventAggregator, _voceValidator, indagine);
            return viewModel as VoceViewModel<U>;
        }
    }
}