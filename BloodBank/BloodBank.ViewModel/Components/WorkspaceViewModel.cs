using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public class WorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<TViewModel>> where TModel : class where TViewModel : ViewModel<TModel> {
        protected readonly IEventAggregator EventAggregator;
        protected readonly IDataService<TModel> DataService;
        protected readonly Func<TViewModel> ViewModelFactory;

        public static IEnumerable<string> HelpRicerca => typeof(TViewModel).PropertyNames(typeof(SearchableAttribute));
        
        public WorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel> dataService, Func<TViewModel> viewModelFactory) {
            EventAggregator = eventAggregator;
            DataService = dataService;
            ViewModelFactory = viewModelFactory;

            DisplayName = typeof(TViewModel).Name;

            Items.AddRange(DataService.GetModels().Select(CreateViewModel));
            if (!typeof(TViewModel).IsDerivedOfGenericType(typeof(CreatableViewModel<>))) {
                DataService.GetObservableCollection().CollectionChanged += (sender, e) => {
                    foreach (TModel model in e.NewItems) {
                        if (!Items.Select(vm => vm.Model).Contains(model)) { }
                        ActivateItem(CreateViewModel(model));
                    }
                };
            }

            ActiveItem = null;
            EventAggregator.Subscribe(this);
        }

        private TViewModel CreateViewModel(TModel model) {
            TViewModel viewModel = ViewModelFactory();
            viewModel.Model = model;
            return viewModel;
        }

        public void OpenNavMenu() {
            EventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void Add() {
            TViewModel vm = ViewModelFactory();
            ActivateItem(vm);
        }

        public void Handle(ViewModelCollectionChangedEvent<TViewModel> message) {
            if (!Items.Contains(message.ViewModel)) {
                Items.Add(message.ViewModel);
                ActiveItem = Items.First(vm => vm == message.ViewModel);
            }
        }
    }
}
