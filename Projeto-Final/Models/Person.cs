using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Final.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        private string Password { get; set; }

    }
}
