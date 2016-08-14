using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

// From https://stackoverflow.com/questions/27374091/writing-a-generic-fluentvalidation-custom-validator-to-check-unique-constraint
namespace BloodBank.Validation.Rules {

    public class UniquePropertyValidator<T> : PropertyValidator {
        private readonly Func<T, string> _propertyAccessorFunc;
        private readonly Func<IEnumerable<T>> _collectionAccessorFunc;

        public UniquePropertyValidator(Func<T, string> propertyAccessorFunc, Func<IEnumerable<T>> collectionAccessorFunc) : base("'{PropertyName}' non è univoco.") {
            _propertyAccessorFunc = propertyAccessorFunc;
            _collectionAccessorFunc = collectionAccessorFunc;
        }

        protected override bool IsValid(PropertyValidatorContext context) {
            if (!(context.Instance is T))
                return false;
            T entity = (T)context.Instance;

            // Get all the entities by executing the lambda
            IEnumerable<T> entities = _collectionAccessorFunc();

            // Get the value of the entity that we are validating by executing the lambda
            string propertyValue = _propertyAccessorFunc(entity);

            // Find the matching entity by executing the propertyAccessorFunc against the
            // entities in the collection and comparing that with the result of the entity
            // that is being validated. Warning SingleOrDefault will throw an exception if
            // multiple items match the supplied predicate
            // http://msdn.microsoft.com/en-us/library/vstudio/bb342451%28v=vs.100%29.aspx
            T matchingEntity = entities.SingleOrDefault(e => _propertyAccessorFunc(e) == propertyValue);
            return matchingEntity == null || matchingEntity.Equals(entity);
        }
    }
}