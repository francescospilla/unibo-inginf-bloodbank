using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Extensions;
using FluentValidation.Validators;

namespace BloodBank.ViewModel.Validation.Donatori {
    public class EtàValidator : PropertyValidator {
        private readonly int _minRange;
        private readonly int _maxRange;

        public EtàValidator(int minRange, int maxRange) : base("'{PropertyName}' deve essere compresa tra i " + minRange + " e " + maxRange + " anni.") {
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
