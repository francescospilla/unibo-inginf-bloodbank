using System;
using BloodBank.Core.Extensions;
using FluentValidation.Validators;

namespace BloodBank.ViewModel.Validation.Donatori {
    public class EtàValidator : PropertyValidator {
        private readonly int _minRange;
        private readonly int _maxRange;

        public EtàValidator(int minRange, int maxRange) : base("'Età' deve essere compresa tra i " + minRange + " e " + maxRange + " anni.") {
            _minRange = minRange;
            _maxRange = maxRange;
        }


        protected override bool IsValid(PropertyValidatorContext context) {
            DateTime? dataNascita = context.PropertyValue as DateTime?;
            if (!dataNascita.HasValue)
                return false;

            int età = dataNascita.Value.Age();
            return _minRange <= età && età <= _maxRange;
        }
    }
}
