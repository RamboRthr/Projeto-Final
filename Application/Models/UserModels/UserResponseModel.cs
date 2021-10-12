using System;

namespace Application.Models.UserModels
{
    public class UserResponseModel : UserAbstractModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
