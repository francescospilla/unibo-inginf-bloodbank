using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests {
    [ImplementPropertyChanged]
    public class VisitaMedicaViewModel : CreatableViewModel<VisitaMedica> {
        private readonly IDataService<Donatore> _donatoreDataService;
        private readonly IDataService<Medico> _medicoDataService;
        private readonly IVisitaMedicaFactory _visitaMedicaFactory;

        #region Constructors

        public VisitaMedicaViewModel(IEventAggregator eventAggregator, IDataService<Donatore> donatoreDataService, IDataService<VisitaMedica> dataService, IDataService<Medico> medicoDataService, IModelValidator<VisitaMedicaViewModel> validator, IVisitaMedicaFactory visitaMedicaFactory) : base(eventAggregator, dataService, validator) {
            _donatoreDataService = donatoreDataService;
            _medicoDataService = medicoDataService;
            _visitaMedicaFactory = visitaMedicaFactory;
            DonatoreEnumerable = _donatoreDataService.GetModels().Where(donatore => donatore.Idoneità != Idoneità.NonIdoneo);
            MedicoEnumerable = _medicoDataService.GetModels();
        }

        #endregion Constructors

        #region Properties

        public new string DisplayName => IsInitialized ? NomeCognomeIdoneità : "Nuova Visita Medica";

        public string NomeCognomeIdoneità => Donatore.Nome + " " + Donatore.Cognome + " (" + Idoneità + ")";
        public string CognomeNome => Donatore.Cognome + " " + Donatore.Nome;

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        #region Data e Ora

        private DateTime? _data = DateTime.Today;
        public DateTime? Data {
            get { return _data; }
            set { SetData(value); }
        }

        private DateTime? _dataOra = DateTime.Now;
        public DateTime? DataOra {
            get { return _dataOra; }
            set { SetDataOra(value); }
        }

        private void SetData(DateTime? value) {
            _data = value?.Date;
            SetDataOra(DataOra);
            ValidateProperty(() => DataOra);
        }

        private void SetDataOra(DateTime? value) {
            if (Data.HasValue && value.HasValue)
                _dataOra = Data.Value.Add(value.Value.TimeOfDay);
            else
                _dataOra = value;
            ValidateProperty(() => Data);
        }

        #endregion

        private Donatore _donatore;
        [Searchable]
        public Donatore Donatore {
            get { return _donatore; }
            set {
                _donatore = value; ValidateProperty(() => Data); ValidateProperty(() => DataOra);
            }
        }

        public string DescrizioneBreve { get; set; }
        public Idoneità Idoneità { get; set; }
        public Medico Medico { get; set; }
        public string Referto { get; set; }

        #endregion Properties

        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();
        public IEnumerable<Donatore> DonatoreEnumerable { get; set; }
        public IEnumerable<Medico> MedicoEnumerable { get; }

        #region Mappings

        protected override void SyncModelToViewModel() {
            DonatoreEnumerable = _donatoreDataService.GetModels();
            Donatore = Model.Donatore;
            DescrizioneBreve = Model.DescrizioneBreve;
            Data = Model.Data;
            DataOra = Model.Data;
            Idoneità = Model.Idoneità;
            Medico = Model.Medico;
            Referto = Model.Referto;
        }

        protected override VisitaMedica CreateModelFromViewModel(out bool isModelAlreadyRegistered) {
            isModelAlreadyRegistered = true;
            return _visitaMedicaFactory.CreateModel(Donatore, DescrizioneBreve, DataOra.GetValueOrDefault(), Idoneità, Medico, Referto);
        }

        protected override void PublishViewModel() {
            EventAggregator.Publish(new ViewModelCollectionChangedEvent<VisitaMedicaViewModel>(this));
        }

        #endregion Mappings
    }
}
