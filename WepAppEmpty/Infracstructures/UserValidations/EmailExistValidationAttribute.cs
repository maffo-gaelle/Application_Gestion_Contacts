using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Models;
using WepAppEmpty.Services;

namespace WepAppEmpty.Infracstructures.UserValidations
{
    public class EmailExistValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;
            UserService userService = (UserService)validationContext.GetService(typeof(UserService));
            User user = userService.Get()
                                   .Where(e => e.Email == email)
                                   .FirstOrDefault();

            return (user == null) ? ValidationResult.Success : new ValidationResult("Cet email existe déjà");
        }
    }
}
