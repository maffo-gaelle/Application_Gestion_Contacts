using Model.Client.Data;
using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Infracstructures.UserValidations
{
    public class UnscribeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            User user = authRepository.Get()
                                      .Where(e => e.Email == email)
                                      .FirstOrDefault();

            return (user != null) ? ValidationResult.Success : new ValidationResult("Cet email n'est pas enregistré. Veuillez vous inscrire !");
        }
    }
}
