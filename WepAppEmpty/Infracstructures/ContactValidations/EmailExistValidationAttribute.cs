using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Models;
using WepAppEmpty.Services;

namespace WepAppEmpty.Infracstructures.ContactValidations
{
    public class EmailExistValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;
            ContactService contactService = (ContactService)validationContext.GetService(typeof(ContactService));
            Contact contact = contactService.Get().Where(e => e.Email == email).FirstOrDefault();

            return (contact == null) ? ValidationResult.Success : new ValidationResult("Cet email existe déjà");
        }
    }
}
