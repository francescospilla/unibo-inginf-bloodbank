﻿using System;
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
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    [AssociatedView("NuovaIndagineBooleanDialogView")]
    public abstract class NuovaIndagineBooleanDialogViewModel : NuovaIndagineDialogViewModel
    {
        protected NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator) {
        }

        #region Properties

        public bool RisultatoCorretto { get; set; }

        #endregion Properties

        public IEnumerable<bool> RisultatoCorrettoEnumerable => typeof (bool).Enumerable() as IEnumerable<bool>;
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
}