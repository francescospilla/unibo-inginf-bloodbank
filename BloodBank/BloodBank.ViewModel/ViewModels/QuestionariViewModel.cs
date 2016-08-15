using System;
using System.Linq;
using BloodBank.Model.Indagini;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class QuestionariViewModel : Conductor<QuestionarioViewModel>.Collection.OneActive {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<ListaIndagini<Questionario>, QuestionarioViewModel> _dataService;
        private readonly Func<QuestionarioViewModel> _viewModelFactory;

        #region Constructors

        public QuestionariViewModel(IEventAggregator eventAggregator, IDataService<ListaIndagini<Questionario>, QuestionarioViewModel> dataService, Func<QuestionarioViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            DisplayName = "Questionari";

            Items.AddRange(_dataService.GetViewModels());
        }

        #endregion Constructors

        #region Actions

        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void AddQuestionario()
        {
            if (Items.All(vm => vm.IsInitialized))
            {
                QuestionarioViewModel vm = _viewModelFactory();
                vm.Nome = "Questionario #" + (Items.Count + 1);
                ActivateItem(vm);
            }
            else
            {
                QuestionarioViewModel emptyViewModel = Items.Single(vm => !vm.IsInitialized);
                ActivateItem(emptyViewModel);
            }

        }

        #endregion Actions
    }
}