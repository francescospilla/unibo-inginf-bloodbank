using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using StructureMap.Attributes;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.ViewModel.Service {
    public class DataService<TModel, TViewModel> : IDataService<TModel, TViewModel> where TModel : class where TViewModel : EditableViewModel<TModel> {
        private IEventAggregator _eventAggregator;
        private IDataService<TModel> _modelService;
        private ObservableCollection<TViewModel> _viewModelList;

        [SetterProperty]
        public Func<TViewModel> ViewModelFactory { get; set; }

        public DataService(IEventAggregator eventAggregator, IDataService<TModel> modelService) {
            _eventAggregator = eventAggregator;
            _modelService = modelService;
        }

        private void Inizialize() {
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
            var viewModel = ViewModelFactory();
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
