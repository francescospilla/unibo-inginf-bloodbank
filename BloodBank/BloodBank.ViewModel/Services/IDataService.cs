using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BloodBank.ViewModel.Services {

    public interface IDataService<TModel> where TModel : class {
        void AddModel(TModel model);
        IEnumerable<TModel> GetModels();
    }
}