using System;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public class TabWorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<TViewModel>> where TModel : class where TViewModel : ViewModel<TModel> {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly IDataService<TModel, TViewModel> _dataService;
        protected readonly Func<TViewModel> _viewModelFactory;

        public TabWorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel, TViewModel> dataService, Func<TViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            DisplayName = typeof(TViewModel).Name;

            ListItems = new BindableCollection<TViewModel>(_dataService.GetViewModels());
            _eventAggregator.Subscribe(this);

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
            if (!ListItems.Contains(message.ViewModel))
                ListItems.Add(message.ViewModel);
        }
    }
}