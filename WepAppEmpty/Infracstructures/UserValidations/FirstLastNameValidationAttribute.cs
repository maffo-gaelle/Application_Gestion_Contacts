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
    public class FirstLastNameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string firstName = value as string;
            //Pour récuperer l'instance de value sur laquelle je me trouve
            string lastName = ((CreateUserForm)validationContext.ObjectInstance).LastName;
            Console.WriteLine("Le firstname du formulaire est " + firstName);
            Console.WriteLine("Le lastName du formulaire est " + lastName);


            UserService _userService = (UserService)validationContext.GetService(typeof(UserService));
            User user = _userService.Get()
                                    .Where(c => c.FirstName == firstName && c.LastName == lastName)
                                    .FirstOrDefault();
            if(user != null)
            {
                Console.WriteLine("Le firstname de la bd est " + user.FirstName);
                Console.WriteLine("Le lastName de la bd est " + user.LastName);
            }

            return user == null ? ValidationResult.Success : new ValidationResult("Cet utilisateur est déjà inscrit");
        }
    }
}
