using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Models.Forms
{
    public class EditContactForm
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
        [DisplayName("Email : ")]
        //[DataType("string")]
        //[DataType(DataType.Password)] 
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le choix d'une catégorie est réquise!")]
        [DisplayName("Catégorie : ")]
        [DataType("int")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
