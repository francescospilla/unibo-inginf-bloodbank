using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Service;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    public class ListaIndaginiQuestionarioViewModel : ListaIndaginiViewModel<Questionario> {

        public ListaIndaginiQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<Indagine<Questionario>> indagineDataService, IDataService<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> dataService, IModelValidator<IListaIndagini> validator) : base(eventAggregator, indagineDataService, dataService, validator) {
        }
    }
}