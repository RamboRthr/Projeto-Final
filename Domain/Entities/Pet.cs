using Domain.Builder;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; protected set; }
        public string Specie { get; protected set; }
        public string Breed { get; protected set; }
        public int AgeYears { get; protected set; }
        public int AgeMonths { get; protected set; }
        public string Size { get; protected set; }
        public bool Adopted { get; protected set; } = false;
        public string Description { get; protected set; }
        public int UserId { get; protected set; }
        public User User { get; protected set; }
        public List<Photo> PetPhotos { get; protected set; }

        public static Pet Creator(PetBuilder petBuilder)
        {
            return new Pet
            {
                Id = petBuilder.Id,
                UserId = petBuilder.UserId,
                Description = petBuilder.Description,
                Name = petBuilder.Name,
                Specie = petBuilder.Specie,
                Breed = petBuilder.Breed,
                AgeYears = petBuilder.AgeYears,
                AgeMonths = petBuilder.AgeMonths,
                Size = petBuilder.Size,
                CreatedAt = DateTime.Now
            };
        }
        public void UpdatePet(Pet updatedPet)
        {
            Name = updatedPet.Name;
            Specie = updatedPet.Specie;
            Breed = updatedPet.Breed;
            AgeYears = updatedPet.AgeYears;
            AgeMonths = updatedPet.AgeMonths;
            Size = updatedPet.Size;
            Description = updatedPet.Description;
            UpdatedAt = DateTime.Now;
        }

        public void ConfirmAdoption() => Adopted = true;
    }
}
