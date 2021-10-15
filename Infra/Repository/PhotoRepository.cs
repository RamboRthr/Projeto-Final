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

        public async Task DeletePhotoRecordFromPet(int id)
        {
            var photo = await Query().SingleOrDefaultAsync(p => p.PetId == id);

            _dbSet.Remove(photo);
        }

        public async Task<Photo> GetPhotoByPetId(int id)
        {
            return await Query().SingleOrDefaultAsync(p => p.PetId == id);
        }
    }
}
