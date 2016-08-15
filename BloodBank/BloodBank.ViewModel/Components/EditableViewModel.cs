using System.Collections.Generic;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public abstract class EditableViewModel<TModel> : Screen where TModel : class {
        protected readonly IEventAggregator EventAggregator;
        protected readonly IDataService<TModel, EditableViewModel<TModel>> DataService;

        #region Constructors

        protected EditableViewModel(IEventAggregator eventAggregator, IDataService<TModel, EditableViewModel<TModel>> dataService, IModelValidator validator) : base(validator) {
            EventAggregator = eventAggregator;
            DataService = dataService;
            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
            IsChanged = false;
        }

        #endregion Constructors

        #region Properties

        private TModel _model;

        public TModel Model {
            get { return _model; }
            set {
                _model = value;
                SyncModelToViewModel();
                IsChanged = false;
            }
        }

        public bool IsInitialized { get { return Model != null; } }
        public bool IsChanged { get; set; }

        #endregion Properties

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanCancel);
        }

        #region Actions

        #region Save

        public bool CanSave {
            get { return IsChanged && !HasErrors; }
        }

        public void Save() {
            if (Validator != null && !Validate()) return;
            if (!IsInitialized) {
                Model = CreateModelFromViewModel();
                // Fody can't weave other assemblies, so we have to manually raise this
                NotifyOfPropertyChange(() => DisplayName);
                DataService.AddModelAndExistingViewModel(Model, this);
            } else
                SyncViewModelToModel();
            IsChanged = false;
        }

        #endregion Save

        #region Cancel

        public bool CanCancel {
            get { return IsInitialized && IsChanged; }
        }

        public void Cancel() {
            SyncModelToViewModel();
            IsChanged = false;
        }

        protected abstract void SyncModelToViewModel();

        protected abstract TModel CreateModelFromViewModel();

        protected abstract void SyncViewModelToModel();

        #endregion Cancel

        #endregion Actions
    }
}