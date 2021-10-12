using Domain.Entities;

namespace Domain.Builder
{
    public class PetBuilder
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Specie { get; private set; }
        public string Breed { get; private set; }
        public string AgeYears { get; private set; }
        public string AgeMonths { get; private set; }
        public string Size { get; private set; }
        public string Description { get; private set; }

        public PetBuilder SetId(int id)
        {
            this.Id = id;
            return this;
        }
        public PetBuilder SetUserId(int userId)
        {
            this.UserId = userId;
            return this;
        }
        public PetBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }
        public PetBuilder SetBreed(string breed)
        {
            this.Breed = breed;
            return this;
        }
        public PetBuilder SetSpecie(string specie)
        {
            this.Specie = specie;
            return this;
        }
        public PetBuilder SetAgeYears(string ageYears)
        {
            this.AgeYears = ageYears;
            return this;
        }
        public PetBuilder SetAgeMonths(string ageMonths)
        {
            this.AgeMonths = ageMonths;
            return this;
        }
        public PetBuilder SetSize(string size)
        {
            this.Size = size;
            return this;
        }
        public PetBuilder SetDescription(string description)
        {
            this.Description = description;
            return this;
        }
        public Pet Build()
        {
            return Pet.Creator(this);
        }
    }
}
