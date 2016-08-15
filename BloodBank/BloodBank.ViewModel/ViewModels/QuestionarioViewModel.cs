using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Service;
using Stylet;

namespace BloodBank.ViewModel {

    public class QuestionarioViewModel : ListaIndaginiViewModel<Questionario> {

        public QuestionarioViewModel(IEventAggregator eventAggregator, IDataService<Indagine> indagineDataService, IDataService<ListaIndagini<Questionario>, QuestionarioViewModel> dataService, IModelValidator<IListaIndagini> validator) : base(eventAggregator, indagineDataService, dataService, validator) {
        }
    }
}