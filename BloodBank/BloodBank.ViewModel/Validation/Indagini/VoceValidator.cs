using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.ViewModels.Indagini;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Indagini {
    public class VoceValidator : AbstractValidator<VoceViewModel> {

        public VoceValidator() {
            RuleFor(vm => vm.Risultato).NotNull();
        }
    }
}
