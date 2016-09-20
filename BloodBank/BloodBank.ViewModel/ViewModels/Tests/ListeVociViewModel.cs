﻿using System;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels.Tests
{
    [AssociatedView("ListeVociView")]
    public class ListeVociViewModel<U> : TabWorkspaceViewModel<ListaVoci<U>, ListaVociViewModel<U>>, IHandle<NuovaListaVociEvent<U>>  where U : ListaVoci
    {
        private readonly Func<NuovaListaVociViewModel<U>> _dialogFactory;

        public ListeVociViewModel(IEventAggregator eventAggregator, IDataService<ListaVoci<U>, ListaVociViewModel<U>> dataService, Func<ListaVociViewModel<U>> viewModelFactory, Func<NuovaListaVociViewModel<U>> dialogFactory) : base(eventAggregator, dataService, viewModelFactory) {
            _dialogFactory = dialogFactory;
        }

        #region Actions

        public void OpenNewDialog() {
            var dialog = _dialogFactory();
            DialogEvent e = new DialogEvent(true, dialog);
            _eventAggregator.Publish(e);
        }

        public void Handle(NuovaListaVociEvent<U> message) {
            _eventAggregator.Publish(new DialogEvent(false, null));
            _dataService.AddModelAndCreatedViewModel(message.ListaVoci);
        }

        #endregion
    }

}
