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
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels.Tests
{
    [AssociatedView("ListeVociView")]
    public class ListeVociViewModel<U> : TabWorkspaceViewModel<ListaVoci<U>, ListaVociViewModel<U>> where U : ListaVoci
    {
        public ListeVociViewModel(IEventAggregator eventAggregator, IDataService<ListaVoci<U>, ListaVociViewModel<U>> dataService, Func<ListaVociViewModel<U>> viewModelFactory) : base(eventAggregator, dataService, viewModelFactory)
        {
        }
    }

}
