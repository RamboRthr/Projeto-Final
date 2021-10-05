using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username Is Missing")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Missing")]
        public string Password { get; set; }
    }
}
