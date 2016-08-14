using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Donatori;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : Conductor<DonatoreViewModel>.Collection.OneActive {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore> _dataService;
        private readonly Func<DonatoreViewModel> _viewModelFactory;

        public BindableCollection<DonatoreViewModel> ListaDonatori { get; }

        #region Constructors
        public DonatoriViewModel(IEventAggregator eventAggregator, IDataService<Donatore> dataService, Func<DonatoreViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            DisplayName = "Donatori";

            IEnumerable<Donatore> models = _dataService.GetModels();

            ListaDonatori = new BindableCollection<DonatoreViewModel>(CreateViewModels(models.ToArray()));

            AddDonatoreTab();
        }
        #endregion

        #region Actions
        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void AddDonatoreTab(DonatoreViewModel viewModel = null)
        {
            ActivateItem(viewModel ?? _viewModelFactory());
        }
        #endregion

        private IEnumerable<DonatoreViewModel> CreateViewModels(params Donatore[] models) {
            return models.Select(donatore => {
                DonatoreViewModel vm = _viewModelFactory();
                vm.Model = donatore;
                return vm;
            });
        }
    }
}
