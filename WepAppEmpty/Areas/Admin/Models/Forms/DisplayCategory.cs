using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Areas.Admin.Models.Forms
{
    public class DisplayCategory
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Nom: ")]
        public string Name { get; set; }
    }
}
