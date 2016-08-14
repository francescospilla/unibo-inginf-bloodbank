using System.Collections.Generic;

namespace BloodBank.Model.Service {

    public interface IDataService<TModel> where TModel : class {
        void AddModel(TModel model);
        IEnumerable<TModel> GetModels();
    }
}