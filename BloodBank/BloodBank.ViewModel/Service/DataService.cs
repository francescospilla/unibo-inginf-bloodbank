using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.ViewModel.Components;
using Ninject;

namespace BloodBank.ViewModel.Service {

    public class DataService<TModel, TViewModel> : IDataService<TModel, TViewModel> where TModel : class where TViewModel : ViewModel<TModel> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<TModel> _modelService;
        private readonly ObservableCollection<TViewModel> _viewModelList;

        // Deve essere inizializzata, preferibilmente con un IoC container.
        [Inject]
        public Func<TViewModel> ViewModelFactoryFunc { get; set; }

        public DataService(IEventAggregator eventAggregator, IDataService<TModel> modelService) {
            _eventAggregator = eventAggregator;
            _modelService = modelService;

            _viewModelList = new ObservableCollection<TViewModel>();

            _modelService.GetObservableCollection().CollectionChanged += (sender, e) => {
                foreach (TModel model in e.NewItems) {
                    if (_viewModelList.Select(vm => vm.Model).Contains(model)) continue;
                    TViewModel viewModel = CreateViewModel(model);
                    _viewModelList.Add(viewModel);
                }
            };

            _viewModelList.CollectionChanged += (sender, e) => {
                foreach (object item in e.NewItems) {
                    _eventAggregator.Publish(new ViewModelCollectionChangedEvent<TViewModel>((TViewModel)item));
                }
            };
        }

        private void Inizialize() {
            if (ViewModelFactoryFunc == null)
                throw new ArgumentNullException("La proprietà '" + nameof(ViewModelFactoryFunc) + "' non è stata assegnata.");

            if (_viewModelList.Any()) return;
            foreach (TModel model in _modelService.GetObservableCollection()) {
                var viewModel = CreateViewModel(model);
                _viewModelList.Add(viewModel);
            }
        }

        public void AddModelAndCreatedViewModel(TModel model) {
            Inizialize();

            _modelService.GetObservableCollection().Add(model);
        }

        public void AddModelAndExistingViewModel(TModel model, object viewModel) {
            Inizialize();
            
            _viewModelList.Add((TViewModel) viewModel);
            _modelService.GetObservableCollection().Add(model);
        }

        private TViewModel CreateViewModel(TModel model) {
            TViewModel viewModel = ViewModelFactoryFunc();
            viewModel.Model = model;
            return viewModel;
        }

        public IEnumerable<TModel> GetModels() {
            Inizialize();

            return _modelService.GetModels();
        }

        public IEnumerable<TViewModel> GetViewModels() {
            Inizialize();

            return new ReadOnlyCollection<TViewModel>(_viewModelList);
        }
    }
}