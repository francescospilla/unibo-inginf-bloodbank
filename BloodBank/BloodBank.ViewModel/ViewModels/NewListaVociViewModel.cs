using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Persone;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
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
    }
}