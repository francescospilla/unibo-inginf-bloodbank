using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    [AssociatedView("NuovaIndagineRangeDialogView")]
    public abstract class NuovaIndagineRangeDialogViewModel<T> : NuovaIndagineDialogViewModel where T : struct, IComparable<T>
    {
        protected NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator) { }

        #region Properties
        
        public T? RangeMin { get; set; }
        public T? RangeMax { get; set; }

        #endregion Properties

        public abstract IEnumerable<T> RangeEnumerable { get; }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeDialogViewModel<U, T> : NuovaIndagineRangeDialogViewModel<T> where T : struct, IComparable<T>
        where U : ListaVoci
    {
        public NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator)
        {
        }

        public override IEnumerable<T> RangeEnumerable => typeof (T).Enumerable() as IEnumerable<T>;

        protected override Indagine CreateModelFromViewModel()
        {
            return new IndagineRange<U, T>(Testo, IdoneitaFallimento, RangeMin.GetValueOrDefault(), RangeMax.GetValueOrDefault());
        }
        

    }

   
}