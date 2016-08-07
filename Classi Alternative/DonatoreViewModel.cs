using System;
using System.Collections.Generic;
using BloodBank.Model;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using Stylet;
using AutoMapper;
using BloodBank.Core.Extensions;
using PropertyChanged;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class DonatoreViewModel : Screen, IDonatore {
        private readonly IWindowManager _windowManager;
        private readonly IModelValidator<IDonatore> _validator;

        #region Constructors

        public DonatoreViewModel(IWindowManager windowManager, IModelValidator<IDonatore> validator, Donatore donatore = null) : base(validator) {
            _windowManager = windowManager;
            _validator = validator;
            Donatore = donatore;
            Validate();
            AutoValidate = true;
        }

        #endregion

        #region Properties
        private Donatore _donatore;
        public Donatore Donatore {
            get { return _donatore; }
            set {
                _donatore = value;
                Mapper.Map(_donatore, this);
                IsInitialized = true;
            }
        }

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

        public bool IsInitialized { get; private set; }
        #endregion

        public IEnumerable<Sesso> SessoEnumerable { get; } = EnumExtensions.Values<Sesso>();
        public IEnumerable<GruppoSanguigno> GruppoSanguignoEnumerable { get; } = EnumExtensions.Values<GruppoSanguigno>();
        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();
        public IEnumerable<bool> AttivoEnumerable { get; } = new[] { true, false };

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanCancel);
        }

        #region Actions

        public void ForceValidation()
        {
            Validate();
        }

        #region Save
        public bool CanSave {
            get { return !HasErrors; }
        }

        public void Save() {
            if (!Validate()) return;
            if (!IsInitialized) {
                _donatore = Mapper.Map<Donatore>(this, opts => opts.ConstructServicesUsing(type => new Donatore(new Contatto(Nome, Cognome, Sesso, DataNascita, CodiceFiscale, Indirizzo, Città, Stato, CodicePostale, Telefono, Email), GruppoSanguigno, Attivo)));
                IsInitialized = true;
            } else
                Mapper.Map(this, _donatore);
        }
        #endregion


        #region Cancel
        public bool CanCancel {
            get { return IsInitialized ; }
        }

        public void Cancel() {
            Mapper.Map(_donatore, this);
        }
        #endregion

        #endregion

    }
}
