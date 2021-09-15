using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public  string CPF { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Key]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Key]
        private string Password { get; set; }

    }
}
