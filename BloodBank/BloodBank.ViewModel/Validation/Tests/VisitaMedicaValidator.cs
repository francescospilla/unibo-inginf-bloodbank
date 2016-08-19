using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Extensions;
using BloodBank.Model.Donatori;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Validation.Donatori;
using BloodBank.ViewModel.ViewModels;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Tests
{
    public class VisitaMedicaValidator : AbstractValidator<VisitaMedicaViewModel>
    {
        public VisitaMedicaValidator(IDataService<VisitaMedica> dataService)
        {
            RuleFor(vm => vm.Donatore).NotEmpty();
            RuleFor(vm => vm.DescrizioneBreve).NotEmpty();
            RuleFor(vm => vm.Idoneità).NotNull().IsInEnum();
            RuleFor(vm => vm.Data).GreaterThan(vm => vm.Donatore.ListaTest.Last().Data).When(vm => vm.Donatore != null && vm.Donatore.ListaTest.Any());
        }
    }
}
