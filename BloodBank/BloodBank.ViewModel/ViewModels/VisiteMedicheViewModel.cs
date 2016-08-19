using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class VisiteMedicheViewModel : Conductor<VisitaMedicaViewModel>.Collection.OneActive, IHandle<ViewModelCollectionChangedEvent<VisitaMedicaViewModel>>
    {

        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<VisitaMedica, VisitaMedicaViewModel> _dataService;
        private readonly Func<VisitaMedicaViewModel> _viewModelFactory;

        public BindableCollection<VisitaMedicaViewModel> ListaVisiteMediche { get; }

        #region Constructors

        public VisiteMedicheViewModel(IEventAggregator eventAggregator, IDataService<VisitaMedica, VisitaMedicaViewModel> dataService, Func<VisitaMedicaViewModel> viewModelFactory)
        {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _viewModelFactory = viewModelFactory;

            _eventAggregator.Subscribe(this);

            DisplayName = "Visite Mediche";

            IEnumerable<VisitaMedica> models = _dataService.GetModels();

            ListaVisiteMediche = new BindableCollection<VisitaMedicaViewModel>(_dataService.GetViewModels());

            AddVisitaMedicaTab();
        }

        #endregion Constructors

        #region Actions

        public void OpenNavMenu()
        {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void AddVisitaMedicaTab(VisitaMedicaViewModel viewModel = null)
        {
            ActivateItem(viewModel ?? _viewModelFactory());
        }
        public void Handle(ViewModelCollectionChangedEvent<VisitaMedicaViewModel> message)
        {
            ListaVisiteMediche.Add(message.ViewModel);
        }
        #endregion Actions
    }
}
