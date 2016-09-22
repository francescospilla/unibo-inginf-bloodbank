using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.ViewModels;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Tests {
    public class NuovaListaVociValidator<U> : AbstractValidator<NuovaListaVociDialogViewModel<U>> where U : ListaVoci {
        public NuovaListaVociValidator() {
            RuleFor(vm => vm.SelectedDonatore).NotEmpty();
            RuleFor(vm => vm.SelectedListaIndagini).NotEmpty();
            RuleFor(vm => vm.GeneratedListVoci).NotEmpty();
            RuleFor(vm => vm.Data).NotNull().LessThanOrEqualTo(vm => DateTime.Today);
            RuleFor(vm => vm.Data).GreaterThanOrEqualTo(vm => vm.SelectedDonatore.ListaTest.Last().Data.Date).When(vm => vm.SelectedDonatore != null && vm.SelectedDonatore.ListaTest.Any());
            RuleFor(vm => vm.DataOra).NotNull().LessThanOrEqualTo(vm => DateTime.Now).WithName("Ora");
            RuleFor(vm => vm.DataOra).GreaterThan(vm => vm.SelectedDonatore.ListaTest.Last().Data).WithName("Ora").When(vm => vm.SelectedDonatore != null && vm.SelectedDonatore.ListaTest.Any());
        }
    }

    public class AnalisiValidator : NuovaListaVociValidator<Analisi> {
    }

    public class QuestionarioValidator : NuovaListaVociValidator<Questionario> {
    }
}
