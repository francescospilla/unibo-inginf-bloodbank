using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stylet;

namespace BloodBank.ViewModel.Services {

    public interface IDataService {
        void AddNewModel(object model);
        IEnumerable<object> GetModels();
        IEnumerable<object> GetViewModels();
    }

    public interface IDataService<TModel, TViewModel> where TModel : class where TViewModel : IScreen {
        void AddNewModel(TModel model);
        ReadOnlyCollection<TModel> GetModels();
        BindableCollection<TViewModel> GetViewModels();
    }
}