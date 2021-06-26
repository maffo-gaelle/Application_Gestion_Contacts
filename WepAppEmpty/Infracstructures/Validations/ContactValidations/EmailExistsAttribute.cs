using Model.Client.Data;
using Model.Client.Repositories;
using Model.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Infracstructures.Validations.ContactValidations
{
    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;
            IContactRepository contactRepository = (IContactRepository)validationContext.GetService(typeof(IContactRepository));
            Contact contact = contactRepository.Get().Where(e => e.Email == email).FirstOrDefault();

            return (contact == null) ? ValidationResult.Success : new ValidationResult("Cet email existe déjà");
        }
    }
}
