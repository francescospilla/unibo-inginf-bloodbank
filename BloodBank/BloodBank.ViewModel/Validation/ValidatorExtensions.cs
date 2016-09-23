using System;
using System.Collections.Generic;
using FluentValidation;

namespace BloodBank.ViewModel.Validation {

    public static class ValidatorExtensions {

        
        /// <typeparam name="T">T is the type of the view model.</typeparam>
        /// <typeparam name="TProperty">TProperty is the type of the validating property.</typeparam>
        /// <typeparam name="U">U is the type of the model.</typeparam>
        public static IRuleBuilderOptions<T, TProperty> MustBeUnique<T, TProperty, U>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<U, TProperty> propertyAccessorFromModelFunc, Func<T, TProperty> propertyAccessorFromViewModelFunc, Func<IEnumerable<U>> modelCollectionAccessorFunc, Func<T, U> modelAccessorFromViewModelFunc = null, Predicate<T> whenPredicate = null) {
            return ruleBuilder.SetValidator(new UniquePropertyValidator<T, TProperty, U>(propertyAccessorFromModelFunc, propertyAccessorFromViewModelFunc, modelCollectionAccessorFunc, modelAccessorFromViewModelFunc, whenPredicate));
        }
    }
}