﻿using BloodBank.Validation.Rules;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace BloodBank.Validation {

    public static class ValidatorExtensions {

        public static IRuleBuilderOptions<T, TProperty> MustBeUnique<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<T, string> propertyAccessorFunc, Func<IEnumerable<T>> collectionAccessorFunc) {
            return ruleBuilder.SetValidator(new UniquePropertyValidator<T>(propertyAccessorFunc, collectionAccessorFunc));
        }
    }
}