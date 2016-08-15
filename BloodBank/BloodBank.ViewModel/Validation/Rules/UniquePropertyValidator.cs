using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

namespace BloodBank.ViewModel.Validation.Rules {

    public class UniquePropertyValidator<T, U> : PropertyValidator {
        private readonly Func<U, object> _propertyAccessorFromModelFunc;
        private readonly Func<T, object> _propertyAccessorFromViewModelFunc;
        private readonly Func<T, U> _modelAccessorFromViewModelFunc;
        private readonly Func<IEnumerable<U>> _modelCollectionAccessorFunc;
        private readonly Predicate<T> _whenPredicate;

        public UniquePropertyValidator(Func<U, object> propertyAccessorFromModelFunc, Func<T, object> propertyAccessorFromViewModelFunc, Func<T, U> modelAccessorFromViewModelFunc, Func<IEnumerable<U>> modelCollectionAccessorFunc, Predicate<T> whenPredicate) : base("'{PropertyName}' non è univoco.")
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
            
            object propertyValue = _propertyAccessorFromViewModelFunc(entity);
            
            U matchingEntity = entities.SingleOrDefault(e => Equals(propertyValue, _propertyAccessorFromModelFunc(e)));
            return matchingEntity == null || _whenPredicate(entity) && Equals(_modelAccessorFromViewModelFunc(entity),matchingEntity);
        }
    }
}