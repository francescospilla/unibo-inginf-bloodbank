using System;
using System.Collections.Generic;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.Validation.Indagini;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public abstract class NuovaIndagineBooleanDialogViewModel : NuovaIndagineDialogViewModel
    {
        protected NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator) {
        }

        #region Properties

        public new string DisplayName = "Nuova Indagine Boolean";

        public bool RisultatoCorretto { get; set; }

        #endregion Properties

        public IEnumerable<bool> RisultatoCorrettoEnumerable { get; } = new[] { true, false };

    }

    [ImplementPropertyChanged]
    public class NuovaIndagineBooleanDialogViewModel<U> : NuovaIndagineBooleanDialogViewModel where U : ListaVoci
    {
        public NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator)
        {
        }

        protected override Indagine CreateModelFromViewModel()
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