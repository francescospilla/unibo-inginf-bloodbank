using System.Linq;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.ViewModels.Tests;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Tests
{
    public class VisitaMedicaValidator : AbstractValidator<VisitaMedicaViewModel>
    {
        public VisitaMedicaValidator()
        {
            RuleFor(vm => vm.Donatore).NotEmpty();
            RuleFor(vm => vm.Medico).NotEmpty();
            RuleFor(vm => vm.DescrizioneBreve).NotEmpty();
            RuleFor(vm => vm.Idoneità).NotNull().IsInEnum();
            RuleFor(vm => vm.DataOra).GreaterThan(vm =>
            vm.Donatore.ListaTest.Last().Data).When(vm => {
                if (vm.IsInitialized) return false;
                if (vm.Donatore == null) return false;

                Test lastTest = vm.Donatore.ListaTest.LastOrDefault();
                if (lastTest == null) return false;

                return true;
            });
            RuleFor(vm => vm.Referto).NotEmpty();
        }
    }
}
