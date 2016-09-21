﻿using System;
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
    public class QuestionariViewModel : TabWorkspaceViewModel<Questionario, ListaVociViewModel<Questionario>>, IHandle<NuovaListaVociEvent<Questionario>>  
    {
        private readonly Func<NuovaListaVociDialogViewModel<Questionario>> _dialogFactory;

        public QuestionariViewModel(IEventAggregator eventAggregator, IDataService<Questionario, ListaVociViewModel<Questionario>> dataService, Func<ListaVociViewModel<Questionario>> viewModelFactory, Func<NuovaListaVociDialogViewModel<Questionario>> dialogFactory) : base(eventAggregator, dataService, viewModelFactory) {
            _dialogFactory = dialogFactory;
        }

        #region Actions

        public void OpenNewDialog() {
            var dialog = _dialogFactory();
            DialogEvent e = new DialogEvent(true, dialog);
            _eventAggregator.Publish(e);
        }

        public void Handle(NuovaListaVociEvent<Questionario> message) {
            _eventAggregator.Publish(new DialogEvent(false, null));
            _dataService.AddModelAndCreatedViewModel(message.ListaVoci);
        }

        #endregion

    }

}
