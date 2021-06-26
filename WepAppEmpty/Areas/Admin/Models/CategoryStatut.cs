using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Areas.Admin.Models
{
    public class CategoryStatut
    {
        public Category category { get; set; }

        public IEnumerable<Contact> ContactsByCategory { get; set; }
    }
}
