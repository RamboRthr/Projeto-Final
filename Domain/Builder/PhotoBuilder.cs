using Domain.Entities;

namespace Domain.Builder
{
    public class PhotoBuilder
    {
        public int PetId { get; private set; }
        public string PhotoPath { get; private set; }

        public PhotoBuilder SetPetId(int petId)
        {
            this.PetId = petId;
            return this;
        }
        public PhotoBuilder SetPhotoPath(string photoPath)
        {
            this.PhotoPath = photoPath;
            return this;
        }
        public Photo Build()
        {
            return Photo.Creator(this);
        }
    }
}
