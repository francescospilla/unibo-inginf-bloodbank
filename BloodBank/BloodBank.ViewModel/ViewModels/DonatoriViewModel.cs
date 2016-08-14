using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Donatori;
using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;
using BloodBank.ViewModel.Service;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : Conductor<DonatoreViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<DonatoreViewModel>> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _dataService;
        private readonly Func<DonatoreViewModel> _viewModelFactory;

        public BindableCollection<DonatoreViewModel> ListaDonatori { get; }

        #region Constructors
        public DonatoriViewModel(IEventAggregator eventAggregator, DataService<Donatore, DonatoreViewModel> dataService, Func<DonatoreViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            _eventAggregator.Subscribe(this);

            DisplayName = "Donatori";

            IEnumerable<Donatore> models = _dataService.GetModels();

            ListaDonatori = new BindableCollection<DonatoreViewModel>(_dataService.GetViewModels());

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

        public void Handle(ViewModelCollectionChangedEvent<DonatoreViewModel> message) {
            ListaDonatori.Add(message.ViewModel);
        }
        #endregion

    }
}
