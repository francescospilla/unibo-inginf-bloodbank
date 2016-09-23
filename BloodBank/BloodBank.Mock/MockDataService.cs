using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Service;

namespace BloodBank.Mock {

    public abstract class MockDataService<TModel> : IDataService<TModel> where TModel : class {
        protected ObservableCollection<TModel> _models;

        public void AddModel(TModel model) {
            if (_models.Contains(model))
                throw new ArgumentException("Model '" + model + "' was already registered in DataService.");
            _models.Add(model);

        }

        public IEnumerable<TModel> GetModels() {
            return new ReadOnlyCollection<TModel>(_models);
        }

        public ObservableCollection<TModel> GetObservableCollection() {
            return _models;
        }
    }
}