using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.ViewModel.Components;

namespace BloodBank.ViewModel.Service {

    public class DataService<TModel, TViewModel> : IDataService<TModel, TViewModel> where TModel : class where TViewModel : ViewModel<TModel> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<TModel> _modelService;
        private ObservableCollection<TViewModel> _viewModelList;

        // Deve essere inizializzata, preferibilmente con un IoC container.
        public Func<TViewModel> ViewModelFactoryFunc { get; set; }

        public DataService(IEventAggregator eventAggregator, IDataService<TModel> modelService) {
            _eventAggregator = eventAggregator;
            _modelService = modelService;
        }

        private void Inizialize() {
            if (ViewModelFactoryFunc == null)
                throw new ArgumentNullException("La proprietà '" + nameof(ViewModelFactoryFunc) + "' non è stata assegnata.");

            if (_viewModelList == null) {
                _viewModelList = new ObservableCollection<TViewModel>(_modelService.GetModels().Select(CreateViewModel));
                _viewModelList.CollectionChanged += (sender, e) => {
                    foreach (object item in e.NewItems) {
                        _eventAggregator.PublishOnUIThread(new ViewModelCollectionChangedEvent<TViewModel>((TViewModel)item));
                    }
                };
            }
        }

        public void AddModel(TModel model) {
            Inizialize();

            _modelService.AddModel(model);
        }

        public void AddModelAndCreatedViewModel(TModel model) {
            Inizialize();

            AddModel(model);
            _viewModelList.Add(CreateViewModel(model));
        }

        public void AddExistingViewModel(object viewModel) {
            Inizialize();

            _viewModelList.Add((TViewModel)viewModel);
        }

        public void AddModelAndExistingViewModel(TModel model, object viewModel) {
            Inizialize();

            AddModel(model);
            AddExistingViewModel(viewModel);
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