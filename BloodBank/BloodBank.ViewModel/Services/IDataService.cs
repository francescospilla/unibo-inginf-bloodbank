using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stylet;

namespace BloodBank.ViewModel.Services {
    public interface IDataService<TModel, out TViewModel> {
        void AddNewModel(TModel model);
        ReadOnlyCollection<TModel> GetModels();
        IEnumerable<TViewModel> GetViewModels();
    }
}