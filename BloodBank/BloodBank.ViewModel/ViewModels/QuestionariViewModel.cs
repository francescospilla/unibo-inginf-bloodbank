using System;
using System.Collections.Generic;
using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class QuestionariViewModel : Conductor<QuestionarioViewModel>.Collection.OneActive {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<ListaIndagini<Questionario>> _dataService;
        private readonly Func<QuestionarioViewModel> _viewModelFactory;

        #region Constructors
        public QuestionariViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<Questionario>> dataService, Func<QuestionarioViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            DisplayName = "Questionari";

            IEnumerable<ListaIndagini<Questionario>> questionari = dataService.GetModels();
            foreach (ListaIndagini<Questionario> questionario in questionari)
            {
                var vm = viewModelFactory();
                vm.Model = questionario;
                Items.Add(vm);
            }
        }
        #endregion

        #region Actions
        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }
        #endregion

    }
}
