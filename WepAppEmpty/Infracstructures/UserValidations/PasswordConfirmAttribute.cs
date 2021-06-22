using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Models;
using WepAppEmpty.Models.Forms;
using WepAppEmpty.Services;

namespace WepAppEmpty.Infracstructures.UserValidations
{
    public class PasswordConfirmAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string passwdConfirm = value as string;
            //Pour récuperer l'instance de value sur laquelle je me trouve
            string passwd = ((CreateUserForm)validationContext.ObjectInstance).Passwd;

            return passwdConfirm == passwd ? ValidationResult.Success : new ValidationResult("Les mots de passe ne sont pas identiques");
        }
    }
}
