using System;
using System.Collections.Generic;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Tests
{
    [ImplementPropertyChanged]
    public class VisitaMedicaViewModel : EditableViewModel<VisitaMedica>
    {
        private readonly IDataService<Donatore> _donatoreDataService;
        private readonly IDataService<Medico> _medicoDataService;

        #region Constructors

        public VisitaMedicaViewModel(IEventAggregator eventAggregator, IDataService<Donatore> donatoreDataService, IDataService<VisitaMedica, VisitaMedicaViewModel> dataService, IDataService<Medico> medicoDataService, IModelValidator<VisitaMedicaViewModel> validator) : base(eventAggregator, dataService, validator)
        {
            _donatoreDataService = donatoreDataService;
            _medicoDataService = medicoDataService;
            DonatoreEnumerable = _donatoreDataService.GetModels();
            MedicoEnumerable = _medicoDataService.GetModels();
        }

        #endregion Constructors

        #region Properties

        public new string DisplayName => IsInitialized ? NomeCognomeIdoneità : "Nuova Visita Medica";

        public string NomeCognomeIdoneità => Donatore.Nome + " " + Donatore.Cognome + " (" + Idoneità + ")";
        public string CognomeNome =>  Donatore.Cognome + " " + Donatore.Nome;

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        [Searchable]
        public Donatore Donatore { get; set; }
        public string DescrizioneBreve { get; set;  }
        public DateTime Data { get; set;  } = DateTime.Now;
        public Idoneità Idoneità { get; set;  }
        public Medico Medico { get; set; }
        public string Referto { get; set; }

        #endregion Properties

        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();
        public IEnumerable<Donatore> DonatoreEnumerable { get; }
        public IEnumerable<Medico> MedicoEnumerable { get; }

    #region Mappings

    protected override void SyncModelToViewModel()
        {
            Donatore = Model.Donatore;
            DescrizioneBreve = Model.DescrizioneBreve;
            Data = Model.Data;
            Idoneità = Model.Idoneità;
            Medico = Model.Medico;
            Referto = Model.Referto;
        }

        protected override VisitaMedica CreateModelFromViewModel()
        {
            return new VisitaMedica(Donatore, DescrizioneBreve, Data, Idoneità, Medico, Referto);
        }

        protected override void SyncViewModelToModel()
        {
            throw new InvalidOperationException();
        }

        #endregion Mappings
    }
}
