using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Services;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class DonatoriViewModel : Conductor<TabWrapperViewModel>.Collection.OneActive {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<IDonatore, DonatoreViewModel> _donatoreService;

        public BindableCollection<DonatoreViewModel> ListaDonatori { get; }

        #region Constructors
        public DonatoriViewModel(IEventAggregator eventAggregator, IDataService<IDonatore, DonatoreViewModel> donatoreService) {
            _eventAggregator = eventAggregator;
            _donatoreService = donatoreService;

            DisplayName = "Donatori";

            ListaDonatori = new BindableCollection<DonatoreViewModel>(_donatoreService.GetViewModels());
            AddDonatoreTab();
        }
        #endregion

        #region Actions
        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }
        
        public void AddDonatoreTab(DonatoreViewModel viewModel = null)
        {
            TabWrapperViewModel donatoreTab = viewModel != null
                ? TabWrapperFactory<DonatoreViewModel>.CreateTab(viewModel) : TabWrapperFactory<DonatoreViewModel>.CreateEmptyTab();
            ActivateItem(donatoreTab);
        }

        #endregion

    }
}
