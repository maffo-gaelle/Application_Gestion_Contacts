using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Areas.Admin.Models.Forms
{
    [HiddenInput]
    public class EditCategoryForm
    {
        public int Id { get; set; }
        [DisplayName("Nom")]
        [Required]
        [MaxLength()]
        public string Name { get; set; }
    }
}
