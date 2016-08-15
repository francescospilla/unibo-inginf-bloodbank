using BloodBank.Model.Donatori;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;
using System;
using System.Collections.Generic;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : Conductor<DonatoreViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<DonatoreViewModel>> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _dataService;
        private readonly Func<DonatoreViewModel> _viewModelFactory;

        public BindableCollection<DonatoreViewModel> ListaDonatori { get; }

        #region Constructors

        public DonatoriViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> dataService, Func<DonatoreViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            _eventAggregator.Subscribe(this);

            DisplayName = "Donatori";

            IEnumerable<Donatore> models = _dataService.GetModels();

            ListaDonatori = new BindableCollection<DonatoreViewModel>(_dataService.GetViewModels());

            AddDonatoreTab();
        }

        #endregion Constructors

        #region Actions

        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void AddDonatoreTab(DonatoreViewModel viewModel = null) {
            ActivateItem(viewModel ?? _viewModelFactory());
        }

        public void Handle(ViewModelCollectionChangedEvent<DonatoreViewModel> message) {
            ListaDonatori.Add(message.ViewModel);
        }

        #endregion Actions
    }
}