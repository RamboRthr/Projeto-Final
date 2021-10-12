using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserWithPets();
        Task<User> VerifyIfUserCpfAlredyExists(string userCpf);
        Task<User> VerifyIfUserEmailAlredyExists(string userEmail);
        Task<List<User>> GetAll();
    }
}
