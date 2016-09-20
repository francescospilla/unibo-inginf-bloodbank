using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BloodBank.Model.Service {

    public abstract class DataService<TModel> : IDataService<TModel> where TModel : class {
        protected ObservableCollection<TModel> _models;

        public void AddModel(TModel model) {
            _models.Add(model);
        }

        public ObservableCollection<TModel> GetModels() {
            return _models;
        }
    }
}