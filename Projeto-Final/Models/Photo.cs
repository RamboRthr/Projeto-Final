using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Final.Models
{
    public class Photo
    {
        public string NamePetPhoto { get; set; }
        public string UserWhoPublishedPhoto { get; set; }
        public DateTime PublicationDatePhoto { get; set; }
        [Key]
        public string PhotoURL { get; set; }
    }
}
