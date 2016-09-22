using System;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels.Tests
{
    [AssociatedView("ListeVociView")]
    public class AnalisiViewModel : TabWorkspaceViewModel<Analisi, ListaVociViewModel<Analisi>> 
    {
        private readonly Func<NuovaListaVociDialogViewModel<Analisi>> _dialogFactory;

        public AnalisiViewModel(IEventAggregator eventAggregator, IDataService<Analisi> dataService, Func<ListaVociViewModel<Analisi>> viewModelFactory, Func<NuovaListaVociDialogViewModel<Analisi>> dialogFactory) : base(eventAggregator, dataService, viewModelFactory) {
            _dialogFactory = dialogFactory;
        }

        #region Actions

        public void OpenNewDialog() {
            var dialog = _dialogFactory();
            DialogEvent e = new DialogEvent(true, dialog);
            _eventAggregator.Publish(e);
        }
        

        #endregion

    }

}
