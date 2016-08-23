using System;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;
using FluentValidation;
using BloodBank.ViewModel.Validation;
using BloodBank.ViewModel.ViewModels;

namespace BloodBank.ViewModel.Validation.Donatori {

    public class DonatoreValidator : AbstractValidator<DonatoreViewModel> {

        public DonatoreValidator(IDataService<Donatore> dataService) {
            RuleFor(d => d.Nome).NotEmpty();
            RuleFor(d => d.Cognome).NotEmpty();
            RuleFor(d => d.Sesso).NotNull().IsInEnum();
            RuleFor(d => d.CodiceFiscale)
                .NotEmpty()
                .Length(CodiceFiscaleValidator.ExpectedLength)
                .SetValidator(new CodiceFiscaleValidator())
                .MustBeUnique(m => m.CodiceFiscale, vm => vm.CodiceFiscale, vm => vm.Model, dataService.GetModels, vm => vm.IsInitialized);
            RuleFor(d => d.DataNascita).NotNull().LessThanOrEqualTo(DateTime.Now);
            RuleFor(d => d.Indirizzo).NotEmpty();
            RuleFor(d => d.Citt‡).NotEmpty();
            RuleFor(d => d.Stato).NotEmpty();
            RuleFor(d => d.CodicePostale)
                .NotEmpty()
                .Must(ParsingExtensions.IsPositiveIntegerNumber)
                .Length(5);
            RuleFor(d => d.Telefono)
                .NotEmpty()
                .Length(6, 11)
                .Must(ParsingExtensions.IsPositiveIntegerNumber).Unless(c => string.IsNullOrEmpty(c.Telefono));
            RuleFor(d => d.Email).NotEmpty().EmailAddress().Unless(c => string.IsNullOrEmpty(c.Email));
            RuleFor(d => d.GruppoSanguigno).NotNull().IsInEnum();
            RuleFor(d => d.DataNascita).SetValidator(new Et‡Validator(Donatore.RangeEt‡.Item1, Donatore.RangeEt‡.Item2));
        }
    }
}