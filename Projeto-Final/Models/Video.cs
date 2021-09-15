using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class Video
    {
        public string NamePetVideo { get; set; }
        public string UserWhoPublishedPhoto { get; set; }
        public DateTime PublicationDateVideo { get; set; }
        [Key]
        public string VideoURL { get; set; }
    }
}
