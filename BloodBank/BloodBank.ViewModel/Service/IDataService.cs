using BloodBank.ViewModel.Components;
using System.Collections.Generic;

namespace BloodBank.ViewModel.Service {

    public interface IDataService<TModel, out TViewModel>
        where TModel : class
        where TViewModel : EditableViewModel<TModel> {

        void AddModel(TModel model);

        void AddModelAndCreatedViewModel(TModel model);

        void AddExistingViewModel(object viewModel);

        void AddModelAndExistingViewModel(TModel model, object viewModel);

        IEnumerable<TModel> GetModels();

        IEnumerable<TViewModel> GetViewModels();
    }
}