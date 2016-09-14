using BloodBank.Model.Models.Tests;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests
{
   public class ListaVociAnalisiViewModel : ListaVociViewModel<Analisi>
    {
       public ListaVociAnalisiViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
       {
       }
    }
}
