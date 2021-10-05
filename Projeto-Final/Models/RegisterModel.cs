using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="NameUser is Missing")]
        public string NameUser { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Missing")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Missing")]
        public string Password { get; set; }
    }
}
