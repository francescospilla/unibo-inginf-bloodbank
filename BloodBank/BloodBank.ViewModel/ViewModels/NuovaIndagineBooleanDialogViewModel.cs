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
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    public class NuovaIndagineBooleanDialogViewModel : Screen
    {
        public NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(validator)
        {
        }

        #region Properties

        public new string DisplayName = "Nuova Indagine Boolean";

        public string Testo { get; set; }
        public Idoneità IdoneitaFallimento { get; set; }
        public bool RisultatoCorretto { get; set; }

        public IndagineBoolean<Questionario> Model { get; set; }

        #endregion Properties

        public IEnumerable<bool> RisultatoCorrettoEnumerable { get; } = new[] { true, false };
        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();

        #region Save

        public bool CanSave
        {
            get { return !HasErrors; }
        }

        public void Save()
        {
            if (Validator != null && !Validate()) return;
                Model = CreateModelFromViewModel();
            //TODO: notifica al view parent
           
        }

        private IndagineBoolean<Questionario> CreateModelFromViewModel()
        {
           return new IndagineBoolean<Questionario>(Testo, IdoneitaFallimento, RisultatoCorretto);
        }

        #endregion Save
    }
}