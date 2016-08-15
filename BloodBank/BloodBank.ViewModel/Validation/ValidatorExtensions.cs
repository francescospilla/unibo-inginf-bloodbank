using System;
using System.Collections.Generic;
using BloodBank.ViewModel.Validation.Rules;
using FluentValidation;

namespace BloodBank.ViewModel.Validation {

    public static class ValidatorExtensions {

        public static IRuleBuilderOptions<T, TProperty> MustBeUnique<T, TProperty, U>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<U, object> propertyAccessorFromModelFunc, Func<T, object> propertyAccessorFromViewModelFunc,
        Func<T, U> modelAccessorFromViewModelFunc, Func<IEnumerable<U>> modelCollectionAccessorFunc, Predicate<T> whenPredicate) {
            return ruleBuilder.SetValidator(new UniquePropertyValidator<T, U>(propertyAccessorFromModelFunc, propertyAccessorFromViewModelFunc, modelAccessorFromViewModelFunc, modelCollectionAccessorFunc, whenPredicate));
        }
    }
}