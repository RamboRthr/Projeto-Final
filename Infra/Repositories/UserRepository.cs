using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserById(int userId)
        {
            return await Query().SingleOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await Query().SingleOrDefaultAsync(user => user.Email == email && user.Password == password);
        }

        public async Task<User> GetUserWithPets()
        {
            return await Query().SingleOrDefaultAsync(user => user.Pets[0].UserId == user.Id);
        }

        public async Task<User> VerifyIfUserCpfAlredyExists(string userCpf)
        {
            return await Query().SingleOrDefaultAsync(user => user.Cpf == userCpf);
        }

        public async Task<User> VerifyIfUserEmailAlredyExists(string userEmail)
        {
            return await Query().SingleOrDefaultAsync(user => user.Email == userEmail);
        }
    }
}
