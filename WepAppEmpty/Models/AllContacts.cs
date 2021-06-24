using Model.Client;
using Model.Client.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Models
{
    public class AllContacts
    {
        public int cpt { get; set; }

        public IEnumerable<Contact> Personnels;
        public IEnumerable<Contact> Professionnal;

        public IEnumerable<Contact> Autres;
        public IEnumerable<Contact> GetAllContacts;

    }
}
