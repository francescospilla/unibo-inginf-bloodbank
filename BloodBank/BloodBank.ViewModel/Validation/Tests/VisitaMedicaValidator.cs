﻿using System.Linq;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.ViewModels;
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
            RuleFor(vm => vm.Data).GreaterThan(vm => vm.Donatore.ListaTest.Last().Data).When(vm => vm.Donatore != null && vm.Donatore.ListaTest.Any());
            RuleFor(vm => vm.Referto).NotEmpty();
        }
    }
}
