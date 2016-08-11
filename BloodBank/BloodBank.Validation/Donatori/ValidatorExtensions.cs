using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Validation.Donatori.Rules;
using FluentValidation;

namespace BloodBank.Validation.Donatori {
    public static class ValidatorExtensions {

        public static IRuleBuilderOptions<T, TProperty> MustBeUnique<T, TProperty>(this IRuleBuilder<T,TProperty> ruleBuilder, Func<T, string> propertyAccessorFunc, Func<IEnumerable<T>> collectionAccessorFunc) {
            return ruleBuilder.SetValidator(new UniquePropertyValidator<T>(propertyAccessorFunc, collectionAccessorFunc));
        }
    }
}
