using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Utils
{
    public class CpfCnpjValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpfCnpj = value as string;

            if(string.IsNullOrEmpty(cpfCnpj) || !CPFCNPJValidator.IsValidCpfCnpj(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}