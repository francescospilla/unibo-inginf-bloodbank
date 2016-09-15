using BloodBank.Model.Models.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests
{
    [ImplementPropertyChanged]
    public class ListaVociQuestionarioViewModel : ListaVociViewModel<Questionario>
    {
       public ListaVociQuestionarioViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
       {
       }
    }
}
