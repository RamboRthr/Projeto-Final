using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Users 
    {
        [Key]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string House_number { get; set; }
        public string CEP { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public bool Adopted { get; set; }
        public bool Donated { get; set; }
        [NotMapped]
        public List<Pets> MyProperty { get; set; }
    }
}
