using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public abstract class NuovaIndagineRangeDialogViewModel<T> : NuovaIndagineDialogViewModel where T : struct, IComparable<T>
    {
        protected NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator) { }

        #region Properties

        public new string DisplayName = "Nuova Indagine Range";
        
        public T? RangeMin { get; set; }
        public T? RangeMax { get; set; }

        #endregion Properties

        public abstract IEnumerable<T> RangeEnumerable { get; }
    }

    [ImplementPropertyChanged]
    public abstract class NuovaIndagineRangeDialogViewModel<U, T> : NuovaIndagineRangeDialogViewModel<T> where T : struct, IComparable<T>
        where U : ListaVoci
    {
        protected NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator)
        {
        }
        
        protected override Indagine CreateModelFromViewModel()
        {
            return new IndagineRange<U, T>(Testo, IdoneitaFallimento, RangeMin.GetValueOrDefault(), RangeMax.GetValueOrDefault());
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeIntAnalisiDialogViewModel : NuovaIndagineRangeDialogViewModel<Analisi, int>
    {
        public override IEnumerable<int> RangeEnumerable { get; } = Enumerable.Range(-1000, 2001).ToList();

        public NuovaIndagineRangeIntAnalisiDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<int>> validator) : base(eventAggregator, validator)
        {
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeDoubleAnalisiDialogViewModel : NuovaIndagineRangeDialogViewModel<Analisi, double>
    {
        public override IEnumerable<double> RangeEnumerable
        {
            get
            {   List<double> lista = Enumerable.Range(-10000, 20001).Select(i => (double) i/10).ToList();
                lista.Insert(0, double.NegativeInfinity);
                lista.Add(double.PositiveInfinity);
                return lista;
            }
        }


        public NuovaIndagineRangeDoubleAnalisiDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<double>> validator) : base(eventAggregator, validator)
        {
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeIntQuestionarioDialogViewModel : NuovaIndagineRangeDialogViewModel<Questionario, int>
    {
        public override IEnumerable<int> RangeEnumerable { get; } = Enumerable.Range(-1000, 2001).ToList();

        public NuovaIndagineRangeIntQuestionarioDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineRangeDialogViewModel<int>> validator) : base(eventAggregator, validator)
        {
        }
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineRangeDoubleQuestionarioDialogViewModel : NuovaIndagineRangeDialogViewModel<Questionario, double>
    {
        public override IEnumerable<double> RangeEnumerable {
            get {
                List<double> lista = Enumerable.Range(-10000, 20001).Select(i => (double)i / 10).ToList();
                lista.Insert(0, double.NegativeInfinity);
                lista.Add(double.PositiveInfinity);
                return lista;
            }
        }


        public NuovaIndagineRangeDoubleQuestionarioDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineRangeDialogViewModel<double>> validator) : base(eventAggregator, validator)
        {
        }
    }
}