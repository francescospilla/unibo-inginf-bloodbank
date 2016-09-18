using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.ViewModels;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Indagini {

    public class NuovaIndagineBooleanValidator : AbstractValidator<NuovaIndagineBooleanDialogViewModel> {
        public NuovaIndagineBooleanValidator(IEnumerable<IDataService<Indagine>> dataServices) {
            RuleFor(vm => vm.Testo).NotEmpty().MustBeUnique(m => m.Testo, vm => vm.Testo, dataServices.PoolAllModels);
            RuleFor(vm => vm.IdoneitaFallimento).NotNull().IsInEnum();
            RuleFor(vm => vm.RisultatoCorretto).NotNull();
        }
    }

    public class NuovaIndagineRangeValidator<T> : AbstractValidator<NuovaIndagineRangeDialogViewModel<T>> where T : struct, IComparable<T>, IComparable {
        public NuovaIndagineRangeValidator(IEnumerable<IDataService<Indagine>> dataServices) {
            RuleFor(vm => vm.Testo).NotEmpty().MustBeUnique(m => m.Testo, vm => vm.Testo, dataServices.PoolAllModels);
            RuleFor(vm => vm.IdoneitaFallimento).NotNull().IsInEnum();
            RuleFor(vm => vm.RangeMin).NotEmpty().LessThanOrEqualTo(vm => vm.RangeMax);
            RuleFor(vm => vm.RangeMax).NotEmpty().GreaterThanOrEqualTo(vm => vm.RangeMin);

        }
    }

    public class NuovaIndagineIntRangeValidator : NuovaIndagineRangeValidator<int> {
        public NuovaIndagineIntRangeValidator(IEnumerable<IDataService<Indagine>> dataService) : base(dataService) {
        }
    }
    public class NuovaIndagineDoubleRangeValidator : NuovaIndagineRangeValidator<double> {
        public NuovaIndagineDoubleRangeValidator(IEnumerable<IDataService<Indagine>> dataService) : base(dataService) {
        }
    }
}
