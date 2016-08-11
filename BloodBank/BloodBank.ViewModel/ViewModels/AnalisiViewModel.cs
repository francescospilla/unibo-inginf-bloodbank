using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {
    
    public class AnalisiViewModel : ListaIndaginiViewModel<Analisi>
    {
        public AnalisiViewModel(IEventAggregator eventAggregator, IDataService<Indagine> indagineDataService, IDataService<ListaIndagini<Analisi>> dataService, IModelValidator<IListaIndagini> validator, ListaIndagini<Analisi> model = null) : base(eventAggregator, indagineDataService, dataService, validator, model)
        {
        }
        
    }
}