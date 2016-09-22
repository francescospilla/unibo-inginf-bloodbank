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
    public class TabWorkspaceViewModel<TModel, TViewModel> : Conductor<TViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<TViewModel>> where TModel : class where TViewModel : ViewModel<TModel> {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly IDataService<TModel> _dataService;
        protected readonly Func<TViewModel> _viewModelFactory;

        public TabWorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel> dataService, Func<TViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            DisplayName = typeof(TViewModel).Name;

            ListItems = new BindableCollection<TViewModel>();
            ListItems.AddRange(_dataService.GetModels().Select(CreateViewModel));

            if (!typeof(TViewModel).IsDerivedOfGenericType(typeof(CreatableViewModel<>))) {
                _dataService.GetObservableCollection().CollectionChanged += (sender, e) => {
                    foreach (TModel model in e.NewItems) {
                        if (!ListItems.Select(vm => vm.Model).Contains(model))
                            ListItems.Add(CreateViewModel(model));
                    }
                };
            }

            _eventAggregator.Subscribe(this);

            AddTab();
        }

        public BindableCollection<TViewModel> ListItems { get; }

        private TViewModel CreateViewModel(TModel model) {
            TViewModel viewModel = _viewModelFactory();
            viewModel.Model = model;
            return viewModel;
        }

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