using System.Collections.Generic;

namespace BloodBank.ViewModel.Services {
    public interface IViewModelFactory<in TModel, out TViewModel>
        where TModel : class
        where TViewModel : IViewModel<TModel> {
        TViewModel CreateViewModel(TModel model);
        IEnumerable<TViewModel> CreateViewModel(IEnumerable<TModel> models);
    }
}