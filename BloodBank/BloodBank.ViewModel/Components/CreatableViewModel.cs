using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public abstract class CreatableViewModel<TModel> : ViewModel<TModel> where TModel : class {
        protected IDataService<TModel, ViewModel<TModel>> DataService;

        protected CreatableViewModel(IEventAggregator eventAggregator, IDataService<TModel, ViewModel<TModel>> dataService, IModelValidator validator = null) : base(eventAggregator, validator) {
            DataService = dataService;
            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
            IsChanged = false;
        }

        #region Properties

        [DoNotSetChanged]
        public override TModel Model {
            get { return base.Model; }
            set {
                base.Model = value;
                IsChanged = false;
                INotifyPropertyChanged notifyPropertyChanged = Model as INotifyPropertyChanged;
                if (notifyPropertyChanged != null)
                    notifyPropertyChanged.PropertyChanged += (sender, args) => { IsChanged = false; };
            }
        }

        public bool IsChanged { get; set; }

        #endregion

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
        }

        #region Action

        #region Save

        public bool CanSave {
            get { return IsChanged && !HasErrors; }
        }

        public virtual void Save() {
            if (Validator != null && !Validate()) return;
            if (!IsInitialized) {
                Model = CreateModelFromViewModel();
                // Fody can't weave other assemblies, so we have to manually raise this
                NotifyOfPropertyChange(() => DisplayName);
                DataService.AddModelAndExistingViewModel(Model, this);
            } else
                throw new InvalidOperationException("Read-only viewModel is already initialized.");
            IsChanged = false;
        }

        #endregion

        #endregion

        protected abstract TModel CreateModelFromViewModel();
    }
}