using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        Task<List<Pet>> GetPetsByUserId(int userId);
        Task<Pet> GetPetById(int petId);
        Task<Pet> VerifyIfPetAlredyExists(Pet pet);
        Task<List<Pet>> GetAll();
    }
}
