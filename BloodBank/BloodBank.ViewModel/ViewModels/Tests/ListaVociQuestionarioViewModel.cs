using BloodBank.Model.Models.Tests;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests
{
   public class ListaVociQuestionarioViewModel : ListaVociViewModel<Questionario>
    {
       public ListaVociQuestionarioViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
       {
       }
    }
}
