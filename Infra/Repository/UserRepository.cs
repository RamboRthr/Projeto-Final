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

        public async Task<User> GetUserById(int id)
        {
            return await Query().SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await Query().SingleOrDefaultAsync(entity => entity.Email == email && entity.Password == password);
        }

        public async Task<User> GetUserWithPets()
        {
            return await Query().SingleOrDefaultAsync(entity => entity.Pets[0].UserId == entity.Id);
        }

        public async Task<User> VerifyIfUserCpfAlredyExists(string userCpf)
        {
            return await Query().SingleOrDefaultAsync(u => u.Cpf == userCpf);
        }

        public async Task<User> VerifyIfUserEmailAlredyExists(string userEmail)
        {
            return await Query().SingleOrDefaultAsync(u => u.Email == userEmail);
        }
    }
}
