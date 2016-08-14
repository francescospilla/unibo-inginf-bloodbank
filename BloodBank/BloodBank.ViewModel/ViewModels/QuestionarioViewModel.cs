using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using BloodBank.Model.Tests;
using Stylet;

namespace BloodBank.ViewModel {
    
    public class QuestionarioViewModel : ListaIndaginiViewModel<Questionario>
    {
        public QuestionarioViewModel(IEventAggregator eventAggregator, IDataService<Indagine> indagineDataService, DataService<ListaIndagini<Questionario>, QuestionarioViewModel> dataService, IModelValidator<IListaIndagini> validator) : base(eventAggregator, indagineDataService, dataService, validator)
        {
        }
        
    }
}