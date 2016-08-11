using System;
using BloodBank.Core.Extensions;
using BloodBank.Model.Donatori;
using FluentValidation;
using FluentValidation.Results;

namespace BloodBank.Validation.Donatori {

/*    public class ContattoValidator : AbstractValidator<IContatto> {

        public ContattoValidator(CodiceFiscaleValidator codiceFiscaleValidator) {
            RuleFor(c => c.Nome).NotEmpty();
            RuleFor(c => c.Cognome).NotEmpty();
            RuleFor(c => c.Sesso).NotNull().IsInEnum();
            RuleFor(c => c.CodiceFiscale)
                .NotEmpty()
                .Length(CodiceFiscaleValidator.ExpectedLength)
                .SetValidator(codiceFiscaleValidator);
            RuleFor(c => c.DataNascita).NotNull().LessThanOrEqualTo(DateTime.Now);
            RuleFor(c => c.Indirizzo).NotEmpty();
            RuleFor(c => c.Città).NotEmpty();
            RuleFor(c => c.Stato).NotEmpty();
            RuleFor(c => c.CodicePostale)
                .NotEmpty()
                .Must(ParsingExtensions.IsPositiveIntegerNumber)
                .Length(5);
            RuleFor(c => c.Telefono)
                .NotEmpty()
                .Length(6, 11)
                .Must(ParsingExtensions.IsPositiveIntegerNumber).Unless(c => string.IsNullOrEmpty(c.Telefono));
            RuleFor(c => c.Email).NotEmpty().EmailAddress().Unless(c => string.IsNullOrEmpty(c.Email));
        }
    }*/
}