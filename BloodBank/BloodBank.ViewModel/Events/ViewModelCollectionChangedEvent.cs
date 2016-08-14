using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.ViewModel.Events {
    public class ViewModelCollectionChangedEvent<TViewModel> where TViewModel : class {
        public TViewModel ViewModel { get; }

        public ViewModelCollectionChangedEvent(TViewModel viewModel) {
            ViewModel = viewModel;
        }
    }
}
