using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Photo
    {
        [Key]
        public int Photo_Id { get; set; }
        public string Pet_name { get; set; }
        public DateTime Publication_date { get; set; }
        public string PhotoURL { get; set; }
    }
}
