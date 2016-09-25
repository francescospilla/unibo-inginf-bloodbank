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
        protected readonly IEventAggregator EventAggregator;
        protected readonly IDataService<TModel> DataService;
        protected readonly Func<TViewModel> ViewModelFactory;

        public TabWorkspaceViewModel(IEventAggregator eventAggregator, IDataService<TModel> dataService, Func<TViewModel> viewModelFactory) {
            EventAggregator = eventAggregator;
            DataService = dataService;
            ViewModelFactory = viewModelFactory;

            DisplayName = typeof(TViewModel).Name;

            ListItems = new BindableCollection<TViewModel>();
            ListItems.AddRange(DataService.GetModels().Select(CreateViewModel));

            if (!typeof(TViewModel).IsDerivedOfGenericType(typeof(CreatableViewModel<>))) {
                DataService.GetObservableCollection().CollectionChanged += (sender, e) => {
                    foreach (TModel model in e.NewItems) {
                        if (!ListItems.Select(vm => vm.Model).Contains(model))
                            ListItems.Add(CreateViewModel(model));
                    }
                };
            }

            EventAggregator.Subscribe(this);

            AddTab();
        }

        public BindableCollection<TViewModel> ListItems { get; }

        private TViewModel CreateViewModel(TModel model) {
            TViewModel viewModel = ViewModelFactory();
            viewModel.Model = model;
            return viewModel;
        }

        public void OpenNavMenu() {
            EventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void AddTab(TViewModel viewModel = null) {
            ActivateItem(viewModel ?? ViewModelFactory());
        }

        public void Handle(ViewModelCollectionChangedEvent<TViewModel> message) {
            if (!ListItems.Contains(message.ViewModel)) {
                ListItems.Add(message.ViewModel);
                ActiveItem = message.ViewModel;
            }
        }
    }
}