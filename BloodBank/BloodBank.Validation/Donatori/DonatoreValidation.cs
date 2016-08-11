using System;
using BloodBank.Core.Extensions;
using BloodBank.Model.Donatori;
using FluentValidation;

namespace BloodBank.Validation.Donatori {

    public class DonatoreValidator : AbstractValidator<IDonatore> {

        /*       TODO: Include() non funziona per ragioni oscure...

                 public DonatoreValidator(ContattoValidator contattoValidator) {
                    Include(contattoValidator);
                    RuleFor(d => d.GruppoSanguigno).NotNull().IsInEnum();
                    RuleFor(d => d.DataNascita)
                        .Must(
                            dataNascita => {
                                int et� = dataNascita.Age();
                                return et� >= Donatore.RangeEt�.Item1 && et� <= Donatore.RangeEt�.Item2;
                            }).WithMessage("L'et� deve essere compresa tra i " + Donatore.RangeEt�.Item1 + " e " + Donatore.RangeEt�.Item2 + " anni.");
                }
        */

        public DonatoreValidator(CodiceFiscaleValidator codiceFiscaleValidator) {
            RuleFor(c => c.Nome).NotEmpty();
            RuleFor(c => c.Cognome).NotEmpty();
            RuleFor(c => c.Sesso).NotNull().IsInEnum();
            RuleFor(c => c.CodiceFiscale)
                .NotEmpty()
                .Length(CodiceFiscaleValidator.ExpectedLength)
                .SetValidator(codiceFiscaleValidator);
            RuleFor(c => c.DataNascita).NotNull().LessThanOrEqualTo(DateTime.Now);
            RuleFor(c => c.Indirizzo).NotEmpty();
            RuleFor(c => c.Citt�).NotEmpty();
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
