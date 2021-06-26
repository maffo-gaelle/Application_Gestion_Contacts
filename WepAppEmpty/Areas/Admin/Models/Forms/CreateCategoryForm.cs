using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Areas.Admin.Infracstructures.Validations;

namespace WepAppEmpty.Areas.Admin.Models.Forms
{
    public class CreateCategoryForm
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nom de la Catégorie")]
        [CategoryExistValidation]
        public string Name { get; set; }
    }
}
