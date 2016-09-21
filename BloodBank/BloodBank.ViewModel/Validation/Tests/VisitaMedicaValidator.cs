using System;
using System.Linq;
using BloodBank.Model.Models;
using BloodBank.ViewModel.ViewModels.Tests;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Tests
{
    public class VisitaMedicaValidator : AbstractValidator<VisitaMedicaViewModel>
    {
        public VisitaMedicaValidator() {
            RuleFor(vm => vm.Donatore).NotEmpty().Must(donatore => donatore?.Idoneità != Idoneità.NonIdoneo).When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.Medico).NotEmpty().When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.DescrizioneBreve).NotEmpty().When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.Idoneità).NotNull().IsInEnum().When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.Data).NotNull().LessThanOrEqualTo(vm => DateTime.Today).When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.Data).GreaterThanOrEqualTo(vm => vm.Donatore.ListaTest.LastOrDefault().Data.Date).When(vm => vm.Donatore != null).When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.DataOra).NotNull().LessThanOrEqualTo(vm => DateTime.Now).WithName("Ora").When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.DataOra).GreaterThan(vm => vm.Donatore.ListaTest.LastOrDefault().Data).WithName("Ora").When(vm => vm.Donatore != null).When(vm => !vm.IsInitialized);
            RuleFor(vm => vm.Referto).NotEmpty().When(vm => !vm.IsInitialized);
        }
    }
}
