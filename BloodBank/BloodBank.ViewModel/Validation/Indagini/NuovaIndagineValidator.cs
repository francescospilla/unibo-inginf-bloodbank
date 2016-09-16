using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.ViewModels;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Indagini
{ 
    public class NuovaIndagineBooleanValidator : AbstractValidator<NuovaIndagineBooleanDialogViewModel>
    {
        public NuovaIndagineBooleanValidator()
        {
            RuleFor(vm => vm.Testo).NotEmpty();
            RuleFor(vm => vm.IdoneitaFallimento).NotNull().IsInEnum();
            RuleFor(vm => vm.RisultatoCorretto).NotNull();
        }
    }

    public class NuovaIndagineRangeValidator<T> : AbstractValidator<NuovaIndagineRangeDialogViewModel<T>> where T : struct, IComparable<T>
    {
        public NuovaIndagineRangeValidator()
        {
            RuleFor(vm => vm.Testo).NotEmpty();
            RuleFor(vm => vm.IdoneitaFallimento).NotNull().IsInEnum();
            RuleFor(vm => vm.RangeMin).NotEmpty();
            RuleFor(vm => vm.RangeMax).NotEmpty();
            RuleFor(vm => vm).Must(vm => vm.RangeMin.GetValueOrDefault().CompareTo(vm.RangeMax.GetValueOrDefault()) <= 0);
        }
    }

    public class NuovaIndagineIntRangeValidator : NuovaIndagineRangeValidator<int> { }
    public class NuovaIndagineDoubleRangeValidator : NuovaIndagineRangeValidator<double> { }
}
