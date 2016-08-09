using System;
using System.Collections.Generic;
using AutoMapper;
using BloodBank.Model.Donatori;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Services;
using BloodBank.ViewModel.ViewModels;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public abstract class EditableViewModel<TModel> : Screen, IEditableViewModel<TModel> where TModel : class {
        protected readonly IEventAggregator EventAggregator;
        protected readonly IDataService<TModel> DataService;

        #region Methods
        public abstract void AddModel(TModel model);
        #endregion

        #region Constructors
        protected EditableViewModel(IEventAggregator eventAggregator, IDataService<TModel> dataService, IModelValidator validator, TModel model = null) : base(validator) {
            EventAggregator = eventAggregator;
            DataService = dataService;
            Model = model;
            AutoValidate = true;
            Validate();
            IsChanged = false;
        }
        #endregion

        #region Properties
        private TModel _model;
        public TModel Model {
            get { return _model; }
            private set {
                _model = value;
                Mapper.Map(_model, this);
            }
        }

        public bool IsInitialized { get { return Model != null; } }

        public bool IsChanged { get; set; }
        public abstract Action<IMappingOperationOptions> MappingOpts { get; }

        #endregion

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanCancel);
        }

        #region Actions

        #region ForceValidation
        public void ForceValidation() {
            Validate();
        }
        #endregion

        #region Save
        public bool CanSave {
            get { return IsChanged && !HasErrors; }
        }

        public void Save() {
            if (!Validate()) return;
            if (!IsInitialized) {
                Model = Mapper.Map<TModel>(this, MappingOpts);
                // Fody can't weave other assemblies, so we have to manually raise this
                NotifyOfPropertyChange(() => DisplayName);
                AddModel(Model);
            } else
                Mapper.Map(this, Model);
            IsChanged = false;
        }
        #endregion

        #region Cancel
        public bool CanCancel {
            get { return IsInitialized && IsChanged; }
        }

        public void Cancel() {
            Mapper.Map(Model, this);
            IsChanged = false;
        }
        #endregion

        #endregion
    }
}
