using FluentValidation;

namespace BloodBank.ViewModel.Validation {
    public class EditableViewModelValidator<TModel> : AbstractValidator<EditableViewModel<TModel>> where TModel : class {

        public EditableViewModelValidator(AbstractValidator<TModel> modelValidator)
        {
            RuleFor(x => x.Model).SetValidator(modelValidator);
        } 
    }
}
