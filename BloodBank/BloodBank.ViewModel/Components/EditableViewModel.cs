using System;
using System.Collections.Generic;
using AutoMapper;
using Stylet;

namespace BloodBank.ViewModel {

    public abstract class EditableViewModel<TModel> : Screen, IEditableViewModel<TModel> where TModel : class {
        #region Constructors

        protected EditableViewModel(IModelValidator<TModel> validator, TModel model = null) : base(validator) {
            Model = model;
            AutoValidate = true;
            Validate();
        }

        #endregion

        #region Properties
        private TModel _model;
        public TModel Model {
            get { return _model; }
            set {
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
