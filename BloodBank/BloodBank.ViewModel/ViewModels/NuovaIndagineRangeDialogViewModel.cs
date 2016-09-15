using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public abstract class NuovaIndagineRangeDialogViewModel<T> : Screen where T : IComparable<T>
    {
        protected NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(validator)
        {
            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
        }

        #region Properties

        public new string DisplayName = "Nuova Indagine Range";

        public string Testo { get; set; }
        public Idoneità IdoneitaFallimento { get; set; }
        public T RangeMin { get; set; }
        public T RangeMax { get; set; }

        #endregion Properties

        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();

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

    public class NuovaIndagineRangeDialogViewModel<U, T> : NuovaIndagineRangeDialogViewModel<T> where T : IComparable<T>
        where U : ListaVoci
    {
        public NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(eventAggregator, validator)
        {
        }

        protected override object CreateModelFromViewModel()
        {
            return new IndagineRange<U, T>(Testo, IdoneitaFallimento, RangeMin, RangeMax);
        }
    }

    public class NuovaIndagineRangeIntAnalisiDialogViewModel : NuovaIndagineRangeDialogViewModel<Analisi, int>
    {
        public NuovaIndagineRangeIntAnalisiDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<int>> validator) : base(eventAggregator, validator)
        {
        }
    }

    public class NuovaIndagineRangeDoubleAnalisiDialogViewModel : NuovaIndagineRangeDialogViewModel<Analisi, double>
    {
        public NuovaIndagineRangeDoubleAnalisiDialogViewModel(IEventAggregator eventAggregator,
            IModelValidator<NuovaIndagineRangeDialogViewModel<double>> validator) : base(eventAggregator, validator)
        {
        }
    }

    public class NuovaIndagineRangeIntQuestionarioDialogViewModel : NuovaIndagineRangeDialogViewModel<Questionario, int>
    {
        public NuovaIndagineRangeIntQuestionarioDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineRangeDialogViewModel<int>> validator) : base(eventAggregator, validator)
        {
        }
    }

    public class NuovaIndagineRangeDoubleQuestionarioDialogViewModel : NuovaIndagineRangeDialogViewModel<Questionario, double>
    {
        public NuovaIndagineRangeDoubleQuestionarioDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineRangeDialogViewModel<double>> validator) : base(eventAggregator, validator)
        {
        }
    }
}