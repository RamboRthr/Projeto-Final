using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(MyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await Query().SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Pet>> GetPetsByUserId(int id)
        {
            return await Query().Where(p => p.UserId == id).ToListAsync();
        }

        public async Task<Pet> VerifyIfPetAlredyExists(Pet pet)
        {
            return await Query().SingleOrDefaultAsync(p => p.UserId == pet.UserId && p.Name == pet.Name && p.AgeYears == pet.AgeYears && p.AgeMonths == pet.AgeMonths && p.Description == pet.Description);
        }
    }
}
