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
                        int et� = dataNascita.Age();
                        return et� >= Donatore.RangeEt�.Item1 && et� <= Donatore.RangeEt�.Item2;
                    }).WithMessage("L'et� deve essere compresa tra i " + Donatore.RangeEt�.Item1 + " e " + Donatore.RangeEt�.Item2 + " anni.");
        }
    }
}
