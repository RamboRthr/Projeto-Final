using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(MyContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteAllPhotoRecordsFromPet(int id)
        {
            var photos = await Query().Where(p => p.PetId == id).ToListAsync();

            foreach (var photo in photos)
            {
                _dbSet.Remove(photo);
            }
        }

        public async Task<List<Photo>> GetPhotosByPetId(int id)
        {
            return await Query().Where(p => p.PetId == id).ToListAsync();
        }
    }
}
