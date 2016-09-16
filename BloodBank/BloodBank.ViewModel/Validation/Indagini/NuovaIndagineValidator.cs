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

    public class NuovaIndagineRangeValidator<T> : AbstractValidator<NuovaIndagineRangeDialogViewModel<T>> where T : struct, IComparable<T>, IComparable
    {
        public NuovaIndagineRangeValidator()
        {
            RuleFor(vm => vm.Testo).NotEmpty();
            RuleFor(vm => vm.IdoneitaFallimento).NotNull().IsInEnum();
            RuleSet("Range", () => {
                RuleFor(vm => vm.RangeMin).NotEmpty().LessThanOrEqualTo(vm => vm.RangeMax);
                RuleFor(vm => vm.RangeMax).NotEmpty().GreaterThanOrEqualTo(vm => vm.RangeMin);
            });

        }
    }

    public class NuovaIndagineIntRangeValidator : NuovaIndagineRangeValidator<int> { }
    public class NuovaIndagineDoubleRangeValidator : NuovaIndagineRangeValidator<double> { }
}
