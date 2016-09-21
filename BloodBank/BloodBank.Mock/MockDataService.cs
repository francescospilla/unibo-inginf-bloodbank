using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Service;

namespace BloodBank.Mock {

    public abstract class MockDataService<TModel> : IDataService<TModel> where TModel : class {
        protected ObservableCollection<TModel> _models;

        public void AddModel(TModel model) {
            _models.Add(model);
        }

        IEnumerable<TModel> IDataService<TModel>.GetModels() {
            return _models.Cast<TModel>();
        }

        public ObservableCollection<TModel> GetObservableCollection() {
            return _models;
        }
    }
}