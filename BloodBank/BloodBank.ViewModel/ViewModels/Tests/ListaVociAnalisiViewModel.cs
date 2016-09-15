using BloodBank.Model.Models.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests
{
    [ImplementPropertyChanged]
    public class ListaVociAnalisiViewModel : ListaVociViewModel<Analisi>
    {
        public ListaVociAnalisiViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}
