using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Persone;
using BloodBank.ViewModel.ViewModels.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class NewDonazioneViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _donatoreDataService;

        private readonly IDataService<VisitaMedica, VisitaMedicaViewModel> _visitaMedicaDataService;
        private IDataService<ListaVoci<Questionario>, ListaVociQuestionarioViewModel> _listaVociQuestionarioDataService;
        private IDataService<ListaVoci<Analisi>, ListaVociAnalisiViewModel> _listaVociAnalisiDataService;

        public NewDonazioneViewModel(IEventAggregator eventAggregator,
            IDataService<Donatore, DonatoreViewModel> donatoreDataService,
            IDataService<ListaVoci<Questionario>, ListaVociQuestionarioViewModel> listaVociQuestionarioDataService,
            IDataService<ListaVoci<Analisi>, ListaVociAnalisiViewModel> listaVociAnalisiDataService,
            IDataService<VisitaMedica, VisitaMedicaViewModel> visitaMedicaDataService)
        {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _listaVociQuestionarioDataService = listaVociQuestionarioDataService;
            _listaVociAnalisiDataService = listaVociAnalisiDataService;
            _visitaMedicaDataService = visitaMedicaDataService;

            DonatoreEnumerable =
                _donatoreDataService.GetViewModels().Where(vm => vm.Idoneità == Idoneità.Idoneo);
        }

        #region Properties

        public DonatoreViewModel SelectedDonatore { get; set; }
        public ViewModel<ListaVoci<Questionario>> SelectedListaVociQuestionario { get; set; }
        public ViewModel<ListaVoci<Analisi>> SelectedListaVociAnalisi { get; set; }
        public VisitaMedicaViewModel SelectedVisitaMedica { get; set; }
        public TipoDonazione SelectedTipoDonazione { get; set; }

        #endregion

        public IEnumerable<DonatoreViewModel> DonatoreEnumerable { get; }
        public IEnumerable<ListaVociQuestionarioViewModel> ListaVociQuestionarioEnumerable { get; private set; }
        public IEnumerable<ListaVociAnalisiViewModel> ListaVociAnalisiEnumerable { get; private set; }
        public IEnumerable<VisitaMedicaViewModel> VisitaMedicaEnumerable { get; private set; }
        public IEnumerable<TipoDonazione> TipoDonazioneEnumerable => TipoDonazione.Values;

        public void RefreshComboBoxes(object sender, EventArgs e)
        {
            if (SelectedDonatore == null)
                return;
            ListaVociAnalisiEnumerable = new BindableCollection<ListaVociAnalisiViewModel>(
                _listaVociAnalisiDataService.GetViewModels()
                    .Where(vm => vm.Donatore.Equals(SelectedDonatore.Model) && vm.Data.Date.Equals(DateTime.Today)));
            ListaVociQuestionarioEnumerable = new BindableCollection<ListaVociQuestionarioViewModel>(
                _listaVociQuestionarioDataService.GetViewModels()
                    .Where(vm => vm.Donatore.Equals(SelectedDonatore.Model) && vm.Data.Date.Equals(DateTime.Today)));
            VisitaMedicaEnumerable = new BindableCollection<VisitaMedicaViewModel>(
                _visitaMedicaDataService.GetViewModels()
                    .Where(vm => vm.Donatore.Equals(SelectedDonatore.Model) && vm.Data.Date.Equals(DateTime.Today)));
        }


        public void OpenNavMenu()
        {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

    }



}
