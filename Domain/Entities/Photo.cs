using Domain.Builder;
using System;

namespace Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string PhotoPath { get; protected set; }
        public int PetId { get; protected set; }
        public Pet Pet { get; protected set; }

        public static Photo Creator(PhotoBuilder photoBuilder)
        {
            return new Photo
            {
                PetId = photoBuilder.PetId,
                PhotoPath = photoBuilder.PhotoPath,
                CreatedAt = DateTime.Now
            };
        }
    }
}
