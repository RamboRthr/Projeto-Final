using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Pets
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
 




    }
}
