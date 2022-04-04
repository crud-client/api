using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrudClients.Validation
{
    public class TypeOfTelphoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;


            string[] telphoneTypes = {"residential", "commercial"};

            if (!telphoneTypes.Contains(value))
            {
                var allowed = String.Join(", ", telphoneTypes);
                return new ValidationResult(
                    $"Invalid telphone type {value}. Allowed values are {allowed}."
                );
            }

            return ValidationResult.Success;
        }
    }
}