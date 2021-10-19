using Application.Models.PetModels;
using System;
using System.Collections.Generic;

namespace Application.Models.UserModels
{
    public class UserResponseModel : UserAbstractModel
    {
        public int Id { get; set; }
        public List<PetResponseModel> Pets { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
