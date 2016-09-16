﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public abstract class NuovaIndagineRangeDialogViewModel<T> : Screen where T : struct, IComparable<T>
    {
        private readonly IEventAggregator _eventAggregator;

        protected NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(validator)
        {
            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
            _eventAggregator = eventAggregator;
        }

        #region Properties

        public new string DisplayName = "Nuova Indagine Range";

        public string Testo { get; set; }
        public Idoneità IdoneitaFallimento { get; set; }
        public T? RangeMin { get; set; }
        public T? RangeMax { get; set; }

        #endregion Properties

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
            SaveIndagineEvent e = new SaveIndagineEvent(CreateModelFromViewModel());
           _eventAggregator.Publish(e);
        }

        protected abstract object CreateModelFromViewModel();

        #endregion Save

    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeDialogViewModel<U, T> : NuovaIndagineRangeDialogViewModel<T> where T : struct, IComparable<T>
        where U : ListaVoci
    {
        public NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator)
        {
        }

        protected override object CreateModelFromViewModel()
        {
            return new IndagineRange<U, T>(Testo, IdoneitaFallimento, RangeMin.GetValueOrDefault(), RangeMax.GetValueOrDefault());
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeIntAnalisiDialogViewModel : NuovaIndagineRangeDialogViewModel<Analisi, int>
    {
        public IEnumerable<int> RangeEnumerable { get; } = Enumerable.Range(-1000, 2000).ToList();

        public NuovaIndagineRangeIntAnalisiDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<int>> validator) : base(eventAggregator, validator)
        {
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeDoubleAnalisiDialogViewModel : NuovaIndagineRangeDialogViewModel<Analisi, double>
    {
        public IEnumerable<double> RangeEnumerable { get; } = Enumerable.Range(-10000, 20000).Select(i => ((double)i) / 10).ToList();


        public NuovaIndagineRangeDoubleAnalisiDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<double>> validator) : base(eventAggregator, validator)
        {
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeIntQuestionarioDialogViewModel : NuovaIndagineRangeDialogViewModel<Questionario, int>
    {
        public IEnumerable<int> RangeEnumerable { get; } = Enumerable.Range(-1000, 2000).ToList();

        public NuovaIndagineRangeIntQuestionarioDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineRangeDialogViewModel<int>> validator) : base(eventAggregator, validator)
        {
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeDoubleQuestionarioDialogViewModel : NuovaIndagineRangeDialogViewModel<Questionario, double>
    {
        public IEnumerable<double> RangeEnumerable { get; } = Enumerable.Range(-10000, 20000).Select(i => ((double)i) / 10).ToList();


        public NuovaIndagineRangeDoubleQuestionarioDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineRangeDialogViewModel<double>> validator) : base(eventAggregator, validator)
        {
        }
    }
}