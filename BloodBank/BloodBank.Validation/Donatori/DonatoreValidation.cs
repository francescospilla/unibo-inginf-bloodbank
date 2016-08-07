using BloodBank.Core.Extensions;
using BloodBank.Model.Donatori;
using FluentValidation;

namespace BloodBank.Validation.Donatori {

    public class DonatoreValidator : ContattoValidator<IDonatore> {
        private static DonatoreValidator _instance;
        public static DonatoreValidator Instance => _instance ?? (_instance = new DonatoreValidator());

        public DonatoreValidator() {
            RuleFor(d => d.GruppoSanguigno).NotNull().IsInEnum();
            RuleFor(d => d.DataNascita)
                .Must(
                    dataNascita => {
                        int età = dataNascita.Age();
                        return età >= Donatore.RangeEtà.Item1 && età <= Donatore.RangeEtà.Item2;
                    }).WithMessage("L'età deve essere compresa tra i " + Donatore.RangeEtà.Item1 + " e " + Donatore.RangeEtà.Item2 + " anni.");
        }
    }
}
