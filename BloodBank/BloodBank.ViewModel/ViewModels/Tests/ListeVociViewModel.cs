using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests
{

    public class ListeVociQuestionarioViewModel : TabWorkspaceViewModel<ListaVoci<Questionario>, ListaVociQuestionarioViewModel>
    {
        public ListeVociQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<ListaVoci<Questionario>, ListaVociQuestionarioViewModel> dataService, Func<ListaVociQuestionarioViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }

    public class ListeVociAnalisiViewModel : TabWorkspaceViewModel<ListaVoci<Analisi>, ListaVociAnalisiViewModel>
    {
        public ListeVociAnalisiViewModel(IEventAggregator eventAggregator, IDataService<ListaVoci<Analisi>, ListaVociAnalisiViewModel> dataService, Func<ListaVociAnalisiViewModel> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }

}
