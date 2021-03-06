using System.Collections.Generic;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {
    public abstract class NuovaIndagineDialogViewModel : Screen {
        private readonly IEventAggregator _eventAggregator;

        protected NuovaIndagineDialogViewModel(IEventAggregator eventAggregator, IModelValidator validator) : base(validator) {
            _eventAggregator = eventAggregator;

            if (validator != null) {
                AutoValidate = true;
                Validate();
            }

        }

        public string Testo { get; set; }
        public Idoneit� IdoneitaFallimento { get; set; }
        public IEnumerable<Idoneit�> Idoneit�Enumerable { get; } = EnumExtensions.Values<Idoneit�>();

        #region Save

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
        }

        public bool CanSave => !HasErrors;

        public void Save() {
            if (Validator != null && !Validate()) return;
            AddModel(CreateModelFromViewModel());
            _eventAggregator.Publish(new DialogEvent(false, null));
        }

        #endregion

        #region Cancel

        public void Cancel() {
            _eventAggregator.Publish(new DialogEvent(false, null));
        }

        #endregion

        protected abstract Indagine CreateModelFromViewModel();
        protected abstract void AddModel(Indagine model);
    }
}