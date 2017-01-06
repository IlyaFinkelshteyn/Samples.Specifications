﻿using System.ComponentModel.DataAnnotations;

namespace Samples.Client.Model.Shared.Validation
{
    public class DoublePositiveValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var number = (double)value;

            if (number < 0.0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}