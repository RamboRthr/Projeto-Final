using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserById(int userId);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> VerifyIfUserCpfAlredyExists(string userCpf);
        Task<User> VerifyIfUserEmailAlredyExists(string userEmail);
    }
}
