using BloodBank.Model.Indagini;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Services;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {
    
    public class QuestionarioViewModel : ListaIndaginiViewModel<Questionario>
    {
        public QuestionarioViewModel(IEventAggregator eventAggregator, IDataService<Indagine> indagineDataService, IDataService<ListaIndagini<Questionario>> dataService, IModelValidator<IListaIndagini> validator, ListaIndagini<Questionario> model = null) : base(eventAggregator, indagineDataService, dataService, validator, model)
        {
        }
        
    }
}