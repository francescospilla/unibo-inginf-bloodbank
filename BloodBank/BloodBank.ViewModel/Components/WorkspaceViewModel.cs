using System;
using System.Linq;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public class WorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<TViewModel>> where TModel : class where TViewModel : ViewModel<TModel> {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly IDataService<TModel, TViewModel> _dataService;
        protected readonly Func<TViewModel> _viewModelFactory;

        public WorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel, TViewModel> dataService, Func<TViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            _eventAggregator.Subscribe(this);

            DisplayName = typeof(TViewModel).Name;

            Items.AddRange(_dataService.GetViewModels());
        }

        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void Add() {
            if (Items.All(vm => vm.IsInitialized)) {
                TViewModel vm = _viewModelFactory();
                ActivateItem(vm);
            } else {
                TViewModel emptyViewModel = Items.Single(vm => !vm.IsInitialized);
                ActivateItem(emptyViewModel);
            }

        }

        public void Handle(ViewModelCollectionChangedEvent<TViewModel> message)
        {
            Items.Add(message.ViewModel);
        }
    }
}
