using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Infracstructures.ContactValidations;

namespace WepAppEmpty.Models.Forms
{
    public class CreateContactForm 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est réquis!")]
        [StringLength(75, ErrorMessage = "Le nombre de caractères doit être compris entre 1 et 75!")]
        [DisplayName("Nom : ")]
        [DataType("string")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Le prénom est réquis!")]
        [StringLength(75)]
        [DisplayName("Prénom : ")]
        [DataType("string")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "L'email est réquis!")]
        [EmailAddress]
        [EmailExists]
        [DisplayName("Email : ")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le choix d'une catégorie est réquise!")]
        [DisplayName("Catégorie : ")]
        [DataType("int")]
        [CategoryIdValidation(ErrorMessage = "La categorie n'est pas valide !")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set;  }

        //constructeur doit être sans paramètre
        //public CreateContactForm()
        //{
        //    Categories = new List<SelectListItem>();
        //}




        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    ContactService contactService = (ContactService)validationContext.GetService(typeof(ContactService));
        //    CategoryService categoryService = (CategoryService)validationContext.GetService(typeof(CategoryService));

        //    Contact contact = (from c in contactService.Get()
        //                       where c.FirstName == FirstName && c.LastName == LastName
        //                       select c).FirstOrDefault();

        //    string email = (from c in contactService.Get()
        //                  where c.Email == Email
        //                  select c.Email).ToString();

        //    var category = categoryService.Get().Where(c => c.Id == CategoryId).SingleOrDefault();

        //    if (contact is not null)
        //        yield return new ValidationResult("Ce contact existe déjà");
        //    if (email != "")
        //        yield return new ValidationResult("Cet email est déjà utilisé");
        //    if (CategoryId == 0)
        //        yield return new ValidationResult("La catégorie Id doit être supérieur à 0");
        //    if(category is null)
        //        yield return new ValidationResult("La catégorie sélectionnée est invalide");
        //}
        //public override bool IsValid(ValidationContext validationContext)
        //{
        //    if (Validate(validationContext).Count() != 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
