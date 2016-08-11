using System.Collections.Generic;
using BloodBank.Model.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public abstract class EditableViewModel<TModel> : Screen where TModel : class {
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
            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
            IsChanged = false;
        }
        #endregion

        #region Properties
        private TModel _model;
        public TModel Model {
            get { return _model; }
            set {
                _model = value;
                SyncModelToViewModel();
            }
        }

        public bool IsInitialized { get { return Model != null; } }
        public bool IsChanged { get; set; }
        #endregion

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
            if (!IsInitialized)
            {
                Model = CreateModelFromViewModel();
                // Fody can't weave other assemblies, so we have to manually raise this
                NotifyOfPropertyChange(() => DisplayName);
                AddModel(Model);
            }
            else
                SyncViewModelToModel();
            IsChanged = false;
        }

        #endregion

        #region Cancel
        public bool CanCancel {
            get { return IsInitialized && IsChanged; }
        }

        public void Cancel()
        {
            SyncModelToViewModel();
            IsChanged = false;
        }

        protected abstract void SyncModelToViewModel();
        protected abstract TModel CreateModelFromViewModel();
        protected abstract void SyncViewModelToModel();

        #endregion

        #endregion
    }
}
