using System.ComponentModel.DataAnnotations;

namespace Application.Models.PhotoModels
{
    public class PhotoAbstractModel
    {
        [Required(ErrorMessage = "O Id do Pet é um campo obrigatório")]
        public int PetId { get; set; }
    }
}
