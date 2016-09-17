﻿using System;
using System.Linq;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public class WorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive where TModel : class where TViewModel : ViewModel<TModel> {
        protected readonly IEventAggregator _eventAggregator;
        private readonly IDataService<TModel, TViewModel> _donatoreDataService;
        private readonly Func<TViewModel> _viewModelFactory;

        public WorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel, TViewModel> donatoreDataService, Func<TViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _viewModelFactory = viewModelFactory;

            DisplayName = typeof(TViewModel).Name;

            Items.AddRange(_donatoreDataService.GetViewModels());
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
    }
}
