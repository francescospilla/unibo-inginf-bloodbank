using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BloodBank.Model.Service {

    public abstract class DataService<TModel> : IDataService<TModel> where TModel : class {
        protected readonly IList<TModel> _models;

        protected DataService(IList<TModel> models) {
            _models = models;
        }

        public void AddModel(TModel model) {
            _models.Add(model);
        }

        public IEnumerable<TModel> GetModels() {
            return new ReadOnlyCollection<TModel>(_models);
        }
    }
}
