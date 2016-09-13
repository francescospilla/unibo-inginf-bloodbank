using System.Collections.Generic;
using BloodBank.Model.Models.Persone;
using BloodBank.ViewModel.Service;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {
    public class NewListaVociViewModel : Screen {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _donatoreDataService;


        #region Constructors

        public NewListaVociViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> donatoreDataService) {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;

            DonatoreEnumerable = _donatoreDataService.GetViewModels();
        }

        #endregion

        #region Properties

        public DonatoreViewModel SelectedDonatore { get; set; }

        #endregion

        public IEnumerable<DonatoreViewModel> DonatoreEnumerable { get; }
    }
}