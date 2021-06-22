using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Infracstructures.UserValidations;

namespace WepAppEmpty.Models.Forms
{
    public class CreateUserForm
    {
        [Required(ErrorMessage = "Le nom est réquis!")]
        [StringLength(50, ErrorMessage = "Le nombre de caractères doit être compris entre 1 et 50!")]
        [DisplayName("Nom : ")]
        [DataType("string")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le prénom est réquis!")]
        [StringLength(50, ErrorMessage = "Le nombre de caractères doit être compris entre 1 et 50!")]
        [DisplayName("Prénom : ")]
        [DataType("string")]
        [FirstLastNameValidation]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "L'email est réquis!")]
        [EmailAddress]
        [EmailExistValidation]
        [DisplayName("Email : ")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Un mot de passe est réquis")]
        [DisplayName("Mot de passe : ")]
        [MinLength(3, ErrorMessage = "minimum de 3 caractères")]
        [MaxLength(8, ErrorMessage = "maximum de 8 caractères")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }

        [PasswordConfirm]
        [DisplayName("Confirmez votre mot de passe : ")]
        [Required(ErrorMessage = "Veuillez confirmer votre mot de passe")]
        [DataType(DataType.Password)]
        public string PasswdConfirm { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }
    }
}
