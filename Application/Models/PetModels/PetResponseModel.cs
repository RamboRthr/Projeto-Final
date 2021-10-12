using System;

namespace Application.Models.PetModels
{
    public class PetResponseModel : PetAbstractModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
