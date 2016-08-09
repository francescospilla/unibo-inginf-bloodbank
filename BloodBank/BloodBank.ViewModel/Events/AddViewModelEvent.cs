using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.ViewModel.Events {
    public class AddViewModelEvent<TModel, TViewModel> where TModel : class where TViewModel : IViewModel<TModel> {

        public AddViewModelEvent(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public TViewModel ViewModel { get; }
    }
}
