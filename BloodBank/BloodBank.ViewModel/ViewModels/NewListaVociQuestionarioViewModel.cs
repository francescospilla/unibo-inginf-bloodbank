using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Persone;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {
    public class NewListaVociQuestionarioViewModel : NewListaVociViewModel<Questionario> {
        public NewListaVociQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<Donatore, DonatoreViewModel> donatoreDataService, IDataService<ListaIndagini<Questionario>, EditableViewModel<ListaIndagini<Questionario>>> listaIndaginiDataService) : base(eventAggregator, donatoreDataService, listaIndaginiDataService) {
        }
    }
}
