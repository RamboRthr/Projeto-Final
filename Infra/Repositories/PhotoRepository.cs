using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(MyContext dbContext) : base(dbContext)
        {
        }

        public async Task DeletePhotoRecordFromPet(int petId)
        {
            var photo = await Query().SingleOrDefaultAsync(pet => pet.PetId == petId);

            _dbSet.Remove(photo);
        }

        public async Task<Photo> GetPhotoByPetId(int petId)
        {
            return await Query().SingleOrDefaultAsync(pet => pet.PetId == petId);
        }
    }
}
