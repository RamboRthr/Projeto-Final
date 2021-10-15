using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPhotoRepository : IGenericRepository<Photo>
    {
        Task<Photo> GetPhotoByPetId(int id);
        Task DeletePhotoRecordFromPet(int id);
    }
}
