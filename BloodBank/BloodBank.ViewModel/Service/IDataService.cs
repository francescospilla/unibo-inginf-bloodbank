using System.Collections.Generic;
using BloodBank.ViewModel.Components;
using Stylet;

namespace BloodBank.ViewModel.Service {

    public interface IDataService<TModel, out TViewModel>
        where TModel : class
        where TViewModel : ViewModel<TModel> {

        void AddModelAndCreatedViewModel(TModel model);
        void AddModelAndExistingViewModel(TModel model, IScreen viewModel);
        IEnumerable<TModel> GetModels();
        IEnumerable<TViewModel> GetViewModels();
    }
}