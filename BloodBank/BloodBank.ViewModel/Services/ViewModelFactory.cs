using System;
using System.Collections.Generic;
using System.Linq;
using Stylet;

namespace BloodBank.ViewModel.Services {

    public class ViewModelFactory<TModel, TViewModel> where TModel : class where TViewModel : IViewModel<TModel> {
        private readonly DataService<TModel> _dataService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IModelValidator<TViewModel> _validator;

        public ViewModelFactory(IEventAggregator eventAggregator, IModelValidator<TViewModel> validator, DataService<TModel> dataService) {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _validator = validator;
        }

        public IEnumerable<TViewModel> CreateViewModel(params TModel[] models) {
            return models.Select(CreateViewModel);
        }

        public TViewModel CreateViewModel(TModel model) {
            return (TViewModel)Activator.CreateInstance(typeof(TViewModel), _eventAggregator, _dataService, this, _validator, model);
        }
    }
}