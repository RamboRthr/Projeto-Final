using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Final.Models
{
    public class Pets
    {
        [Key]
        public int Id { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public bool Adopted { get; set; }
        public string OldOwner { get; set; }
        public string NewOwner { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
