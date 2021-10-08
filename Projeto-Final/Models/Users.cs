using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Users : IdentityUser
    {
        [Key]
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }

        public string CPF { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string House_number { get; set; }
        public string CEP { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Adopted { get; set; }
        public bool Donated { get; set; }
        
    }
}
