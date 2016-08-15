using System;
using BloodBank.Core.Extensions;
using BloodBank.Model.Donatori;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.Validation.Rules;
using FluentValidation;
using BloodBank.ViewModel.Validation;
using BloodBank.ViewModel.ViewModels;

namespace BloodBank.ViewModel.Validation.Donatori {

    public class DonatoreValidator : AbstractValidator<DonatoreViewModel> {

        public DonatoreValidator(CodiceFiscaleValidator codiceFiscaleValidator, IDataService<Donatore> dataService) {
            RuleFor(d => d.Nome).NotEmpty();
            RuleFor(d => d.Cognome).NotEmpty();
            RuleFor(d => d.Sesso).NotNull().IsInEnum();
            RuleFor(d => d.CodiceFiscale)
                .NotEmpty()
                .Length(CodiceFiscaleValidator.ExpectedLength)
                .SetValidator(codiceFiscaleValidator)
                .MustBeUnique(m => m.CodiceFiscale, vm => vm.CodiceFiscale, vm => vm.Model, dataService.GetModels, vm => vm.IsInitialized);
            RuleFor(d => d.DataNascita).NotNull().LessThanOrEqualTo(DateTime.Now);
            RuleFor(d => d.Indirizzo).NotEmpty();
            RuleFor(d => d.Citt�).NotEmpty();
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
            RuleFor(d => d.DataNascita)
                .Must(
                    dataNascita => {
                        int et� = dataNascita.Age();
                        return et� >= Donatore.RangeEt�.Item1 && et� <= Donatore.RangeEt�.Item2;
                    }).WithMessage("'Et�' deve essere compresa tra i " + Donatore.RangeEt�.Item1 + " e " + Donatore.RangeEt�.Item2 + " anni.");
        }
    }
}