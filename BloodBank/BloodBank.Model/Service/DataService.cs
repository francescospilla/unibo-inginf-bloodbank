using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BloodBank.Model.Service {

    public abstract class DataService<TModel> : IDataService<TModel> where TModel : class {
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