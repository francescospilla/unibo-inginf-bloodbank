using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Service;

namespace BloodBank.Mock {

    public abstract class MockDataService<TModel> : IDataService<TModel> where TModel : class {
        protected ObservableCollection<object> _models;

        public void AddModel(object model) {
            _models.Add(model);
        }

        IEnumerable<TModel> IDataService<TModel>.GetModels() {
            return _models.Cast<TModel>();
        }

        public ObservableCollection<object> GetObservableCollection() {
            return _models;
        }
    }
}