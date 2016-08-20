using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public class WorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive where TModel : class where TViewModel : ViewModel<TModel> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<TModel, TViewModel> _dataService;
        private readonly Func<TViewModel> _viewModelFactory;

        public WorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel, TViewModel> dataService, Func<TViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

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
    }
}
