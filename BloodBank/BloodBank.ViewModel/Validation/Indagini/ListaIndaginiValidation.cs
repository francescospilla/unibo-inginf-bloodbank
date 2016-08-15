using BloodBank.Model.Indagini;
using FluentValidation;

namespace BloodBank.ViewModel.Validation.Indagini {

    public class ListaIndaginiValidator : AbstractValidator<IListaIndagini> {

        public ListaIndaginiValidator() {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Indagini).NotEmpty();
            RuleFor(x => x.DataUltimaModifica).GreaterThanOrEqualTo(x => x.DataCreazione);
        }
    }
}