using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class DonatoriViewModel : Conductor<TabWrapperViewModel>.Collection.OneActive, IHandle<AddViewModelEvent<Donatore, DonatoreViewModel>> {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore> _dataService;
        private readonly ViewModelFactory<Donatore, DonatoreViewModel> _viewModelFactory;

        public BindableCollection<DonatoreViewModel> ListaDonatori { get; }

        #region Constructors
        public DonatoriViewModel(IEventAggregator eventAggregator, DataService<Donatore> dataService, ViewModelFactory<Donatore, DonatoreViewModel> viewModelFactory) {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            _eventAggregator.Subscribe(this);
            
            DisplayName = "Donatori";

            IEnumerable<Donatore> models = _dataService.GetModels();
            ListaDonatori = new BindableCollection<DonatoreViewModel>(_viewModelFactory.CreateViewModel(models.ToArray()));

            AddDonatoreTab();
        }
        #endregion

        #region Actions
        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void AddDonatoreTab(DonatoreViewModel viewModel = null) {
            TabWrapperViewModel donatoreTab = viewModel != null
                ? TabWrapperFactory<DonatoreViewModel>.CreateTab(viewModel) : TabWrapperFactory<DonatoreViewModel>.CreateEmptyTab();
            ActivateItem(donatoreTab);
        }
        #endregion

        public void Handle(AddViewModelEvent<Donatore, DonatoreViewModel> message) {
            ListaDonatori.Add(message.ViewModel);
        }

        public void FaccioFintaDiFareQualcosa()
        {
            Console.WriteLine("Click");
        }
    }
}
