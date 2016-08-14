using System;
using System.Collections.Generic;
using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class QuestionariViewModel : Conductor<QuestionarioViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<QuestionarioViewModel>> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<ListaIndagini<Questionario>, QuestionarioViewModel> _dataService;

        #region Constructors
        public QuestionariViewModel(IEventAggregator eventAggregator, DataService<ListaIndagini<Questionario>, QuestionarioViewModel> dataService) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;

            DisplayName = "Questionari";

            Items.AddRange(dataService.GetViewModels());

            
        }
        #endregion

        #region Actions
        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }
        #endregion

        #region Implementation of IHandle<in ViewModelCollectionChangedEvent<QuestionarioViewModel>>

        public void Handle(ViewModelCollectionChangedEvent<QuestionarioViewModel> message)
        {
           Items.Add(message.ViewModel);
        }

        #endregion
    }
}
