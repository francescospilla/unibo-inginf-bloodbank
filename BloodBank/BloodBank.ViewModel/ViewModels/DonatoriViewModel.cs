using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Services;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : Conductor<TabWrapperViewModel>.Collection.OneActive {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore> _dataService;
        private readonly Func<DonatoreViewModel> _viewModelFactory;
        private readonly Func<TabWrapperViewModel> _tabFactory;

        public BindableCollection<DonatoreViewModel> ListaDonatori { get; }

        #region Constructors
        public DonatoriViewModel(IEventAggregator eventAggregator, IDataService<Donatore> dataService, Func<DonatoreViewModel> viewModelFactory, Func<TabWrapperViewModel> tabFactory ) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;
            _tabFactory = tabFactory;

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
            TabWrapperViewModel tab = _tabFactory();
            tab.ActiveItem = viewModel ?? _viewModelFactory();
            ActivateItem(tab);
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
