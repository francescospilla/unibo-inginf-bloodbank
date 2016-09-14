using System.Collections.Generic;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public abstract class EditableViewModel<TModel> : ViewModel<TModel> where TModel : class {
        protected readonly IDataService<TModel, ViewModel<TModel>> DataService;

        #region Constructors

        protected EditableViewModel(IEventAggregator eventAggregator, IDataService<TModel, ViewModel<TModel>> dataService, IModelValidator validator = null) : base(eventAggregator, validator) {
            DataService = dataService;
            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
            IsChanged = false;
        }

        #endregion Constructors

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanCancel);
        }

        #region Properties
        
        [DoNotSetChanged]
        public override TModel Model {
            get { return base.Model; }
            set {
                base.Model = value;
                IsChanged = false;
            }
        }

        public bool IsChanged { get; set; }

        #endregion

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

        protected abstract TModel CreateModelFromViewModel();

        protected abstract void SyncViewModelToModel();

        #endregion Cancel

        #endregion Actions
    }
}