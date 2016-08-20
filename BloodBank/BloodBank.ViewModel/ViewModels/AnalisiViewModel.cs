using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Service;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    public class AnalisiViewModel : ListaIndaginiViewModel<Analisi> {

        public AnalisiViewModel(IEventAggregator eventAggregator, IDataService<Indagine<Analisi>> indagineDataService, IDataService<ListaIndagini<Analisi>, AnalisiViewModel> dataService, IModelValidator<IListaIndagini> validator) : base(eventAggregator, indagineDataService, dataService, validator) {
        }
    }
}