using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels {
    [ImplementPropertyChanged]
    [AssociatedView("NuovaIndagineRangeDialogView")]
    public abstract class NuovaIndagineRangeDialogViewModel<T> : NuovaIndagineDialogViewModel where T : struct, IComparable<T> {
        protected NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator) { }

        #region Properties

        private T? _rangeMin;
        private T? _rangeMax;

        public T? RangeMin {
            get { return _rangeMin; }
            set { _rangeMin = value; ValidateProperty(() => RangeMax); }
        }


        public T? RangeMax {
            get { return _rangeMax; }
            set { _rangeMax = value; ValidateProperty(() => RangeMin); }
        }

        #endregion Properties

        public abstract IEnumerable<T> RangeEnumerable { get; }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeDialogViewModel<U, T> : NuovaIndagineRangeDialogViewModel<T> where T : struct, IComparable<T>
        where U : ListaVoci {
        private readonly IDataService<Indagine<U>> _dataService;

        public NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator, IDataService<Indagine<U>> dataService,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator) {
            _dataService = dataService;
        }

        public string Type => typeof(U).ToString().Split('.').Last();
        public override IEnumerable<T> RangeEnumerable => typeof(T).Enumerable() as IEnumerable<T>;

        protected override Indagine CreateModelFromViewModel() {
            return new IndagineRange<U, T>(Testo, IdoneitaFallimento, RangeMin.GetValueOrDefault(), RangeMax.GetValueOrDefault());
        }

        protected override void AddModel(Indagine model) {
            _dataService.AddModel((Indagine<U>)model);
        }
    }


}