using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

namespace BloodBank.ViewModel.Validation {

    public class UniquePropertyValidator<T, TProperty, U> : PropertyValidator {
        private readonly Func<U, TProperty> _propertyAccessorFromModelFunc;
        private readonly Func<T, TProperty> _propertyAccessorFromViewModelFunc;
        private readonly Func<T, U> _modelAccessorFromViewModelFunc;
        private readonly Func<IEnumerable<U>> _modelCollectionAccessorFunc;
        private readonly Predicate<T> _whenPredicate;

        public UniquePropertyValidator(Func<U, TProperty> propertyAccessorFromModelFunc, Func<T, TProperty> propertyAccessorFromViewModelFunc, Func<IEnumerable<U>> modelCollectionAccessorFunc, Func<T, U> modelAccessorFromViewModelFunc = null, Predicate<T> whenPredicate = null) : base("'{PropertyName}' non è univoco.")
        {
            _propertyAccessorFromModelFunc = propertyAccessorFromModelFunc;
            _propertyAccessorFromViewModelFunc = propertyAccessorFromViewModelFunc;
            _modelAccessorFromViewModelFunc = modelAccessorFromViewModelFunc;
            _modelCollectionAccessorFunc = modelCollectionAccessorFunc;
            _whenPredicate = whenPredicate;
        }

        protected override bool IsValid(PropertyValidatorContext context) {
            if (!(context.Instance is T))
                return false;
            T entity = (T)context.Instance;
            
            IEnumerable<U> entities = _modelCollectionAccessorFunc();

            TProperty propertyValue = _propertyAccessorFromViewModelFunc(entity);
            
            U matchingEntity = entities.SingleOrDefault(e => Equals(propertyValue, _propertyAccessorFromModelFunc(e)));

            if (_whenPredicate == null || _modelAccessorFromViewModelFunc == null)
                return matchingEntity == null;

            return matchingEntity == null || _whenPredicate(entity) && Equals(_modelAccessorFromViewModelFunc(entity),matchingEntity);
        }
    }
}