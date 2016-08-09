using System;
using System.Collections.Generic;
using AutoMapper;
using BloodBank.Core.Extensions;
using BloodBank.Model;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Services;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class DonatoreViewModel : EditableViewModel<Donatore>, IDonatore {

        protected ViewModelFactory<Donatore, DonatoreViewModel> ViewModelFactory { get; }
        public sealed override Action<IMappingOperationOptions> MappingOpts { get; }

        public override void AddModel(Donatore model) {
            DataService.AddModel(model);
            DonatoreViewModel newViewModel = ViewModelFactory.CreateViewModel(model);
            EventAggregator.PublishOnUIThread(new AddViewModelEvent<Donatore, DonatoreViewModel>(newViewModel));
        }

        #region Constructors
        public DonatoreViewModel(IEventAggregator eventAggregator, DataService<Donatore> dataService, ViewModelFactory<Donatore, DonatoreViewModel> viewModelFactory, IModelValidator<DonatoreViewModel> validator, Donatore donatore = null) : base(eventAggregator, dataService, validator, donatore) {
            MappingOpts = opts => opts.ConstructServicesUsing(type => new Donatore(new Contatto(Nome, Cognome, Sesso, DataNascita, CodiceFiscale, Indirizzo, Città, Stato, CodicePostale, Telefono, Email), GruppoSanguigno, Attivo));
            ViewModelFactory = viewModelFactory;
        }
        #endregion

        #region Properties
        public new string DisplayName => IsInitialized ? NomeCognome : "Nuovo donatore";

        public string NomeCognome => Nome + " " + Cognome;
        public string CognomeNome => Cognome + " " + Nome;

        // TODO: Aggiustare?
        public string StringaRicerca
            => NomeCognome + " " + "s:" + Sesso + " " + "cf:" + CodiceFiscale + " " + "gs:" + GruppoSanguigno + " " + "i:" + Idoneità + " " + (Attivo ? "a:Attivo" : "a:NonAttivo");

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Sesso Sesso { get; set; }
        public string CodiceFiscale { get; set; }
        public DateTime DataNascita { get; set; } = DateTime.Today;
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public string Stato { get; set; }
        public string CodicePostale { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public GruppoSanguigno GruppoSanguigno { get; set; }
        public Idoneità? Idoneità { get; set; }
        public bool Attivo { get; set; }
        #endregion

        public IEnumerable<Sesso> SessoEnumerable { get; } = EnumExtensions.Values<Sesso>();
        public IEnumerable<GruppoSanguigno> GruppoSanguignoEnumerable { get; } = EnumExtensions.Values<GruppoSanguigno>();
        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();
        public IEnumerable<bool> AttivoEnumerable { get; } = new[] { true, false };
    }
}
