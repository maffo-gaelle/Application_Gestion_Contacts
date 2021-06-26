using Model.Client.Data;
using Model.Client.Repositories;
using Model.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Models;

namespace WepAppEmpty.Infracstructures.Validations.UserValidations
{
    public class EmailExistValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository _authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));
            
            string email = value as string;

            if(!string.IsNullOrWhiteSpace(email))
            {
                if(_authRepository.EmailExists(email))
                {
                    return new ValidationResult("Cet email existe déjà !");
                }
            } else
            {
                return new ValidationResult("Email invalide");
            }

            return ValidationResult.Success;
        }

    }
}
