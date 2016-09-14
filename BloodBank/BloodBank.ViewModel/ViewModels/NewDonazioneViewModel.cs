using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
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
        private IDataService<ListaVoci<Questionario>, ViewModel<ListaVoci<Questionario>>> _listaIndaginiQuestionarioDataService;
        private IDataService<ListaVoci<Analisi>, ViewModel<ListaVoci<Analisi>>> _listaIndaginiAnalisiDataService;

        public NewDonazioneViewModel(IEventAggregator eventAggregator,
            IDataService<Donatore, DonatoreViewModel> donatoreDataService,
            IDataService<ListaVoci<Questionario>, ViewModel<ListaVoci<Questionario>>> listaIndaginiQuestionarioDataService, IDataService<ListaVoci<Analisi>, ViewModel<ListaVoci<Analisi>>> listaIndaginiAnalisiDataService,
            IDataService<VisitaMedica, VisitaMedicaViewModel> visitaMedicaDataService)
        {
            _eventAggregator = eventAggregator;
            _donatoreDataService = donatoreDataService;
            _listaIndaginiQuestionarioDataService = listaIndaginiQuestionarioDataService;
            _listaIndaginiAnalisiDataService = listaIndaginiAnalisiDataService;
            _visitaMedicaDataService = visitaMedicaDataService;

            DonatoreEnumerable = _donatoreDataService.GetViewModels();
            ListaIndaginiQuestionarioEnumerable = _listaIndaginiQuestionarioDataService.GetViewModels();
             ListaIndaginiAnalisiEnumerable = _listaIndaginiAnalisiDataService.GetViewModels();
            VisitaMedicaEnumerable = _visitaMedicaDataService.GetViewModels();
        }

        #region Properties

        public DonatoreViewModel SelectedDonatore { get; set; }
        public ViewModel<ListaVoci<Questionario>> SelectedListaIndaginiQuestionario { get; set; }
        public ViewModel<ListaVoci<Analisi>> SelectedListaIndaginiAnalisi { get; set; }
        public VisitaMedicaViewModel SelectedVisitaMedica { get; set; }
        public  TipoDonazione SelectedTipoDonazione { get; set; }

        #endregion

        public IEnumerable<DonatoreViewModel> DonatoreEnumerable { get; }
        public IEnumerable<ViewModel<ListaVoci<Questionario>>> ListaIndaginiQuestionarioEnumerable { get; }
        public IEnumerable<ViewModel<ListaVoci<Analisi>>> ListaIndaginiAnalisiEnumerable { get; }
        public IEnumerable<VisitaMedicaViewModel> VisitaMedicaEnumerable { get; }
        public IEnumerable<TipoDonazione> TipoDonazioneEnumerable => TipoDonazione.Values;
    }
}
