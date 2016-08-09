using System.Collections.Generic;

namespace BloodBank.ViewModel.Services {

    public interface IDataService<TModel> where TModel : class {
        void AddModel(TModel model);
        IEnumerable<TModel> GetModels();
    }
}