using Application.Models.PhotoModels;
using Application.Models.UserModels;
using System;

namespace Application.Models.PetModels
{
    public class PetResponseModel : PetAbstractModel
    {
        public int Id { get; set; }
        public UserResponseModel User { get; set; }
        public PhotoResponseModel PetPhoto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
