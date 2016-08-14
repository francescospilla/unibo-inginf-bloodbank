using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace BloodBank.Validation {

    public class CodiceFiscaleValidator : PropertyValidator {
        public const int ExpectedLength = 16;

        public CodiceFiscaleValidator() : base("'{PropertyName}' non rispetta la validazione formale.") {
        }

        protected override bool IsValid(PropertyValidatorContext context) {
            string codiceFiscale = context.PropertyValue as string;

            if (string.IsNullOrEmpty(codiceFiscale))
                return false;

            string codicefiscale = codiceFiscale.ToUpper();
            const string listaPosizione = "A0B1C2D3E4F5G6H7I8J9KLMNOPQRSTUVWXYZ";
            char[] listaControllo = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int[] listaPari = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            int[] listaDispari = { 1, 1, 0, 0, 5, 5, 7, 7, 9, 9, 13, 13, 15, 15, 17, 17, 19, 19, 21, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };

            Regex regex = new Regex(@"^[A-Z]{6}[\d]{2}[A-Z][\d]{2}[A-Z][\d]{3}[A-Z]$");
            Match m = regex.Match(codicefiscale);

            if (!m.Success) return false;
            int somma = 0;
            for (int i = 0; i < 15; i++) {
                char[] c = codicefiscale.Substring(i, 1).ToCharArray();
                int j = listaPosizione.IndexOf(c[0]);
                if (j < 0)
                    return false;

                somma = (i + 1) % 2 == 0 ? somma + listaPari[j] : somma + listaDispari[j];
            }
            return listaControllo[somma % 26].ToString() == codicefiscale.Substring(15, 1) ? true : false;
        }
    }
}