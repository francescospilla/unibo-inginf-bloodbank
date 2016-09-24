using System;
using System.Collections.Generic;
using System.ComponentModel;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public abstract class EditableViewModel<TModel> : CreatableViewModel<TModel> where TModel : class {

        protected EditableViewModel(IEventAggregator eventAggregator, IDataService<TModel> dataService, IModelValidator validator = null) : base(eventAggregator, dataService, validator) {
            this.Bind(model => model.IsChanged, (sender, args) => NotifyOfPropertyChange(() => CanCancel));
        }

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanCancel);
        }

        #region Actions

        #region Save

        public override void Save() {
            if (Validator != null && !Validate()) return;
            if (!IsInitialized) {
                bool isModelAlreadyRegistered;
                Model = CreateModelFromViewModel(out isModelAlreadyRegistered);
                // Fody can't weave other assemblies, so we have to manually raise this
                NotifyOfPropertyChange(() => DisplayName);
                if (!isModelAlreadyRegistered)
                    DataService.AddModel(Model);
                PublishViewModel();
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

        #endregion Cancel

        #endregion Actions

        protected abstract void SyncViewModelToModel();

    }
}