using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BloodBank.Mock;
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
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    [AssociatedView("NewListaVociView")]
    public class NewListaVociViewModel<U> : Screen where U : ListaVoci {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _donatoreDataService;
        private readonly IDataService<ListaIndagini<U>, EditableViewModel<ListaIndagini<U>>> _listaIndaginiDataService;


        #region Constructors

        public NewListaVociViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> donatoreDataService, IDataService<ListaIndagini<U>, EditableViewModel<ListaIndagini<U>>> listaIndaginiDataService) {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _listaIndaginiDataService = listaIndaginiDataService;

            DonatoreEnumerable = _donatoreDataService.GetViewModels();
            ListaIndaginiEnumerable = _listaIndaginiDataService.GetViewModels();
        }

        #endregion

        #region Properties

        public DonatoreViewModel SelectedDonatore { get; set; }
        public EditableViewModel<ListaIndagini<U>> SelectedListaIndagini { get; set; }

        #endregion

        public IEnumerable<DonatoreViewModel> DonatoreEnumerable { get; }
        public IEnumerable<EditableViewModel<ListaIndagini<U>>> ListaIndaginiEnumerable { get; }
        // TODO : Cambiare in U
        public IEnumerable<VoceViewModel<U>> VociViewModelEnumerable { get; private set; }

        public void OnChangeToNextPage()
        {
            if (SelectedListaIndagini != null)
            {
                VociViewModelEnumerable = CreateViewModelsFrom(SelectedListaIndagini);
            }
        }

        // TODO: Sostituire sto mock
        private static IEnumerable<VoceViewModel<U>> CreateViewModelsFrom(EditableViewModel<ListaIndagini<U>> selectedListaIndagini)
        {
            return selectedListaIndagini.Model.Cast<Indagine<U>>().Select(CreateViewModelFrom).ToList();
        }

        private static VoceViewModel<U> CreateViewModelFrom(Indagine<U> indagine)
        {
            Type thisType = indagine.GetType();
            Type[] genericTypeArguments = indagine.GetType().GenericTypeArguments;
            return null;
        }
    }
}