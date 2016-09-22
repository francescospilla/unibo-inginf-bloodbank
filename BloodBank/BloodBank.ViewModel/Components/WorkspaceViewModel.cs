using System;
using System.Linq;
using BloodBank.Core.Extensions;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public class WorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<TViewModel>> where TModel : class where TViewModel : ViewModel<TModel> {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly IDataService<TModel> _dataService;
        protected readonly Func<TViewModel> _viewModelFactory;

        public WorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel> dataService, Func<TViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            DisplayName = typeof(TViewModel).Name;

            Items.AddRange(_dataService.GetModels().Select(CreateViewModel));
            if (!typeof(TViewModel).IsDerivedOfGenericType(typeof(CreatableViewModel<>))) {
                _dataService.GetObservableCollection().CollectionChanged += (sender, e) => {
                    foreach (TModel model in e.NewItems) {
                        if (!Items.Select(vm => vm.Model).Contains(model))
                            Items.Add(CreateViewModel(model));
                    }
                };
            }

            _eventAggregator.Subscribe(this);
        }

        private TViewModel CreateViewModel(TModel model) {
            TViewModel viewModel = _viewModelFactory();
            viewModel.Model = model;
            return viewModel;
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

        public void Handle(ViewModelCollectionChangedEvent<TViewModel> message) {
            if (!Items.Contains(message.ViewModel))
                Items.Add(message.ViewModel);
        }
    }
}
