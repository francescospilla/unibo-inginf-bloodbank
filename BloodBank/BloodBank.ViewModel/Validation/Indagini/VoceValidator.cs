using System;
using BloodBank.ViewModel.ViewModels.Indagini;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Indagini {
    public class VoceValidator<T> : AbstractValidator<VoceViewModel<T>> where T : struct, IComparable<T> {

        public VoceValidator() {
            RuleFor(vm => vm.Risposta).NotNull();
        }
    }

    // TODO: Perchè non posso rimuoverli?
    public class VoceBoolValidator : VoceValidator<bool> {
    }

    public class VoceIntValidator : VoceValidator<int> {
    }

    public class VoceDoubleValidator : VoceValidator<double> {
    }
}
