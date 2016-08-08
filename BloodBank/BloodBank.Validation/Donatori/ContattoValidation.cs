using System;
using System.Text.RegularExpressions;
using BloodBank.Core.Extensions;
using BloodBank.Model.Donatori;
using FluentValidation;
using FluentValidation.Results;

namespace BloodBank.Validation.Donatori {

    public abstract class ContattoValidator<T> : AbstractValidator<T> where T : IContatto {

        protected ContattoValidator() {
            RuleFor(c => c.Nome).NotEmpty();
            RuleFor(c => c.Cognome).NotEmpty();
            RuleFor(c => c.Sesso).NotNull().IsInEnum();
            RuleFor(c => c.CodiceFiscale)
                .NotEmpty()
                .Length(CodiceFiscaleValidator.ExpectedLength)
                .SetValidator(CodiceFiscaleValidator.Instance);
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
    }

    public class CodiceFiscaleValidator : AbstractValidator<string> {
        private static CodiceFiscaleValidator _instance;
        public static CodiceFiscaleValidator Instance => _instance ?? (_instance = new CodiceFiscaleValidator());

        private CodiceFiscaleValidator() {
            Custom(ValidateCodiceFiscale);
        }

        public static readonly int ExpectedLength = 16;

        private static ValidationFailure ValidateCodiceFiscale(string codiceFiscale) {

            ValidationFailure errorResult = new ValidationFailure("Codice Fiscale", "Il codice fiscale non rispetta la validazione formale.");

            string codicefiscale = codiceFiscale.ToUpper();
            const string listaPosizione = "A0B1C2D3E4F5G6H7I8J9KLMNOPQRSTUVWXYZ";
            char[] listaControllo = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int[] listaPari = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            int[] listaDispari = { 1, 1, 0, 0, 5, 5, 7, 7, 9, 9, 13, 13, 15, 15, 17, 17, 19, 19, 21, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };

            Regex regex = new Regex(@"^[A-Z]{6}[\d]{2}[A-Z][\d]{2}[A-Z][\d]{3}[A-Z]$");
            Match m = regex.Match(codicefiscale);

            if (!m.Success) return errorResult;
            int somma = 0;
            for (int i = 0; i < 15; i++) {
                char[] c = codicefiscale.Substring(i, 1).ToCharArray();
                int j = listaPosizione.IndexOf(c[0]);
                if (j < 0)
                    return errorResult;

                somma = (i + 1) % 2 == 0 ? somma + listaPari[j] : somma + listaDispari[j];
            }
            return listaControllo[somma % 26].ToString() == codicefiscale.Substring(15, 1) ? null : errorResult;
        }
    }

}