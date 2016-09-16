using System;
using System.Collections.Generic;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.Validation.Indagini;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public abstract class NuovaIndagineBooleanDialogViewModel : Screen
    {
        protected NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(validator) {
            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
        }

        #region Properties

        public new string DisplayName = "Nuova Indagine Boolean";

        public string Testo { get; set; }
        public Idoneità IdoneitaFallimento { get; set; }
        public bool RisultatoCorretto { get; set; }

        #endregion Properties

        public IEnumerable<bool> RisultatoCorrettoEnumerable { get; } = new[] { true, false };
        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
        }

        #region Save

        public bool CanSave => !HasErrors;

        public void Save()
        {
            if (Validator != null && !Validate()) return;
            object model = CreateModelFromViewModel();
            //TODO: notifica al view parent

        }

        protected abstract object CreateModelFromViewModel();

        #endregion Save
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineBooleanDialogViewModel<U> : NuovaIndagineBooleanDialogViewModel where U : ListaVoci
    {
        public NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator)
        {
        }

        protected override object CreateModelFromViewModel()
        {
            return new IndagineBoolean<U>(Testo, IdoneitaFallimento, RisultatoCorretto);
        }

    }

    [ImplementPropertyChanged]
    public class NuovaIndagineBooleanQuestionarioDialogViewModel : NuovaIndagineBooleanDialogViewModel<Questionario>
    {
        public NuovaIndagineBooleanQuestionarioDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator)
        {
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineBooleanAnalisiDialogViewModel : NuovaIndagineBooleanDialogViewModel<Analisi>
    {
        public NuovaIndagineBooleanAnalisiDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator)
        {
        }
    }
}