using System.Collections.Generic;
using Stylet;

namespace BloodBank.ViewModel.Services {
    public interface IDataService<out TModel, out TViewModel> where TViewModel : ValidatingModelBase {
        IEnumerable<TModel> GetModels();
        IEnumerable<TViewModel> GetViewModels();
    }
}