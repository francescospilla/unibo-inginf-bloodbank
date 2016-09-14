using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Indagini;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests {

    public class ListaIndaginiQuestionarioViewModel : ListaIndaginiViewModel<Questionario> {

        public ListaIndaginiQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<Indagine<Questionario>> indagineDataService, IDataService<ListaIndagini<Questionario>, ListaIndaginiQuestionarioViewModel> dataService, IModelValidator<IListaIndagini> validator) : base(eventAggregator, indagineDataService, dataService, validator) {
        }
    }
}