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

        public async Task<Pet> GetPetById(int petId)
        {
            return await Query().SingleOrDefaultAsync(pet => pet.Id == petId);
        }

        public async Task<List<Pet>> GetPetsByUserId(int userId)
        {
            return await Query().Where(pet => pet.UserId == userId).ToListAsync();
        }

        public async Task<Pet> VerifyIfPetAlredyExists(Pet pet)
        {
            return await Query().SingleOrDefaultAsync(
                entityPet => 
                entityPet.UserId == pet.UserId && 
                entityPet.Name == pet.Name && 
                entityPet.AgeYears == pet.AgeYears && 
                entityPet.AgeMonths == pet.AgeMonths && 
                entityPet.Description == pet.Description);
        }
    }
}
