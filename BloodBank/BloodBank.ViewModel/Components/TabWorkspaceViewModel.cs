using System;
using System.Collections.Generic;
using BloodBank.Model.Donatori;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public class TabWorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<TViewModel>> where TModel : class where TViewModel : ViewModel<TModel> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<TModel, TViewModel> _dataService;
        private readonly Func<TViewModel> _viewModelFactory;

        public TabWorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel, TViewModel> dataService, Func<TViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            _eventAggregator.Subscribe(this);

            DisplayName = typeof(TViewModel).Name;

            ListItems = new BindableCollection<TViewModel>(_dataService.GetViewModels());

            AddTab();
        }

        public BindableCollection<TViewModel> ListItems { get; }

        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void AddTab(TViewModel viewModel = null) {
            ActivateItem(viewModel ?? _viewModelFactory());
        }

        public void Handle(ViewModelCollectionChangedEvent<TViewModel> message) {
            ListItems.Add(message.ViewModel);
        }
    }
}