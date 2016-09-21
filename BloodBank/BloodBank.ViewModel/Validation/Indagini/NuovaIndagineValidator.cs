using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
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
            RuleFor(vm => vm.RangeMin).NotEmpty();
            RuleFor(vm => vm.RangeMin).LessThanOrEqualTo(vm => vm.RangeMax).When(vm => vm.RangeMax != null);
            RuleFor(vm => vm.RangeMax).NotEmpty();
            RuleFor(vm => vm.RangeMax).GreaterThanOrEqualTo(vm => vm.RangeMin).When(vm => vm.RangeMin != null);

        }
    }

    // TODO: Perchè non posso rimuoverli?
    public class NuovaIndagineIntRangeValidator : NuovaIndagineRangeValidator<int> {
        public NuovaIndagineIntRangeValidator(IEnumerable<IDataService<Indagine>> dataService) : base(dataService) {
        }
    }
    public class NuovaIndagineDoubleRangeValidator : NuovaIndagineRangeValidator<double> {
        public NuovaIndagineDoubleRangeValidator(IEnumerable<IDataService<Indagine>> dataService) : base(dataService) {
        }
    }
}
