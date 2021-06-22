using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Models.Forms
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Un Email est requis")]       
        public string Email { get; set; }

        [Required(ErrorMessage = "Un mot de passe est requis")]
        public string Passwd { get; set; }
    }
}
