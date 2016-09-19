using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
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
