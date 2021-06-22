using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Models
{
    public class User
    {
        public int id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }
        public string Passwd { get; set; }

    }
}
