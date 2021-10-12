using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPhotoRepository : IGenericRepository<Photo>
    {
        Task<List<Photo>> GetPhotosByPetId(int id);
        Task DeleteAllPhotoRecordsFromPet(int id);
    }
}
