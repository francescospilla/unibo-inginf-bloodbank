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
    public class NuovaDonazioneDialogViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Donatore, DonatoreViewModel> _donatoreDataService;
        private readonly IDataService<VisitaMedica, VisitaMedicaViewModel> _visitaMedicaDataService;
        private IDataService<ListaVoci<Questionario>, ListaVociQuestionarioViewModel> _listaVociQuestionarioDataService;
        private IDataService<ListaVoci<Analisi>, ListaVociAnalisiViewModel> _listaVociAnalisiDataService;

        public NuovaDonazioneDialogViewModel(IEventAggregator eventAggregator,
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
                _donatoreDataService.GetViewModels().Where(vm => vm.Idoneità == Idoneità.Idoneo && vm.Attivo);
        }

        #region Properties

        public DonatoreViewModel SelectedDonatore { get; set; }
        public ViewModel<ListaVoci<Questionario>> SelectedListaVociQuestionario { get; set; }
        public ViewModel<ListaVoci<Analisi>> SelectedListaVociAnalisi { get; set; }
        public VisitaMedicaViewModel SelectedVisitaMedica { get; set; }
        public TipoDonazione SelectedTipoDonazione { get; set; }

        public bool CanMoveTo2ndPage => SelectedDonatore != null;
        public bool CanMoveTo3rdPage => SelectedListaVociQuestionario != null;
        public bool CanMoveTo4thPage => SelectedListaVociAnalisi != null;
        public bool CanMoveTo5thPage => SelectedVisitaMedica != null;
        public bool CanMoveToLastPage => SelectedTipoDonazione != null;

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
            ListaVociAnalisiEnumerable = _listaVociAnalisiDataService.GetViewModels().Where(vm => vm.Donatore.Equals(SelectedDonatore.Model) && vm.Data.Date.Equals(DateTime.Today) && vm.Idoneità == Idoneità.Idoneo);
            ListaVociQuestionarioEnumerable = _listaVociQuestionarioDataService.GetViewModels().Where(vm => vm.Donatore.Equals(SelectedDonatore.Model) && vm.Data.Date.Equals(DateTime.Today) && vm.Idoneità == Idoneità.Idoneo);
            VisitaMedicaEnumerable = _visitaMedicaDataService.GetViewModels().Where(vm => vm.Donatore.Equals(SelectedDonatore.Model) && vm.Data.Date.Equals(DateTime.Today) && vm.Idoneità == Idoneità.Idoneo);
        }

        public void OpenNavMenu()
        {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        public void Finish()
        {
            NuovaDonazioneEvent message = new NuovaDonazioneEvent(new Donazione(SelectedDonatore.Model, SelectedTipoDonazione, DateTime.Now, SelectedVisitaMedica.Model, (Analisi) SelectedListaVociAnalisi.Model, (Questionario) SelectedListaVociQuestionario.Model));
            _eventAggregator.Publish(message);
        }

        public void Cancel()
        {
            _eventAggregator.Publish(new DialogEvent(false, null));
        }

    }



}
