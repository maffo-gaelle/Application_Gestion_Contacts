using Model.Client;
using Model.Client.Data;
using Model.Client.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Areas.Admin.Models
{
    public class AllContacts
    {
        public IEnumerable<Contact> Contacts { get; set; }

        public Dictionary<Category, List<Contact>> Dictionnary { get; set; } = new Dictionary<Category, List<Contact>>();
    }
}
