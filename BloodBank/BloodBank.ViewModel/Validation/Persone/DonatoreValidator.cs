using System;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;
using BloodBank.ViewModel.ViewModels.Persone;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Persone {

    public class DonatoreValidator : AbstractValidator<DonatoreViewModel> {

        public DonatoreValidator(IDataService<Donatore> dataService, CodiceFiscaleValidator codiceFiscaleValidator) {
            RuleFor(vm => vm.Nome).NotEmpty();
            RuleFor(vm => vm.Cognome).NotEmpty();
            RuleFor(vm => vm.Sesso).NotNull().IsInEnum();
            RuleFor(vm => vm.CodiceFiscale)
                .NotEmpty()
                .Length(CodiceFiscaleValidator.ExpectedLength)
                .SetValidator(codiceFiscaleValidator)
                .MustBeUnique(m => m.Contatto.CodiceFiscale, vm => vm.CodiceFiscale, dataService.GetModels, vm => vm.Model, vm => vm.IsInitialized);
            RuleFor(vm => vm.DataNascita).NotNull().LessThanOrEqualTo(vm => DateTime.Now);
            RuleFor(vm => vm.Indirizzo).NotEmpty();
            RuleFor(vm => vm.Citt‡).NotEmpty();
            RuleFor(vm => vm.Stato).NotEmpty();
            RuleFor(vm => vm.CodicePostale)
                .NotEmpty()
                .Must(ParsingExtensions.IsPositiveIntegerNumber)
                .Length(5);
            RuleFor(vm => vm.Telefono)
                .NotEmpty()
                .Length(6, 11)
                .Must(ParsingExtensions.IsPositiveIntegerNumber).Unless(c => string.IsNullOrEmpty(c.Telefono));
            RuleFor(vm => vm.Email).NotEmpty().EmailAddress().Unless(c => string.IsNullOrEmpty(c.Email));
            RuleFor(vm => vm.GruppoSanguigno).NotNull().IsInEnum();
            RuleFor(vm => vm.DataNascita).SetValidator(new Et‡Validator(Donatore.RangeEt‡.Item1, Donatore.RangeEt‡.Item2));
        }
    }
}