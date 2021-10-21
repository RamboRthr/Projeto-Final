using Domain.Builder;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Infra.Context;
using Infra.Repository;
using System.Threading.Tasks;
using Xunit;

namespace Tests._4_Data
{
    [Collection("Non-Parallel Collection")]
    public class PetRepositoryTests
    {
        private readonly MyContext _dbContext;
        private readonly IPetRepository _petRepository;

        public PetRepositoryTests()
        {
            _dbContext = new MyContextInMemoryDB().CreateInMemoryMyContext();
            _petRepository = new PetRepository(_dbContext);
        }

        [Fact]
        public async Task Get_All_Pets()
        {
            var pet = PetBuilderForTest();
            await _petRepository.Create(pet);
            await _petRepository.Save();

            var petsReturned = await _petRepository.GetAll();

            petsReturned.Should().HaveCount(1);
        }

        [Fact]
        public async Task Create_pet()
        {
            var pet = PetBuilderForTest();
            var petCreated = await _petRepository.Create(pet);

            petCreated.Should().NotBeNull();
            petCreated.Id.Should().Be(pet.Id);
            petCreated.UserId.Should().Be(pet.UserId);
            petCreated.Name.Should().Be("name");
            petCreated.Breed.Should().Be("breed");
            petCreated.Specie.Should().Be("specie");
            petCreated.AgeYears.Should().Be("ageYears");
            petCreated.Size.Should().Be("size");
            petCreated.Description.Should().Be("description");

        }

        [Fact]
        public async Task Get_pet_By_Id()
        {
            var pet = PetBuilderForTest();
            await _petRepository.Create(pet);
            await _petRepository.Save();

            var petReturned = await _petRepository.GetById(pet.Id);

            petReturned.Should().NotBeNull();
            petReturned.Id.Should().Be(pet.Id);
        }

        [Fact]
        public async Task Update_Pet()
        {
            var pet = PetBuilderForTest();
            await _petRepository.Create(pet);

            var petUpdated = PetUpdatedBuilderForTest();
            pet.UpdatePet(petUpdated);

            _petRepository.Update(pet);

            pet.Id.Should().Be(pet.Id);
            pet.UserId.Should().Be(pet.UserId);
            pet.Name.Should().Be("name teste");
            pet.Breed.Should().Be("breed teste");
            pet.Specie.Should().Be("specie teste");
            pet.AgeYears.Should().Be("ageYears teste");
            pet.AgeMonths.Should().Be("ageMonths teste");
            pet.Size.Should().Be("size teste");
            pet.Description.Should().Be("description teste");
        }


        private Pet PetUpdatedBuilderForTest()
        {
            return new PetBuilder()
                .SetId(1)
                .SetName("name teste")
                .SetBreed("breed teste")
                .SetSpecie("specie teste")
                .SetAgeYears("ageYears teste")
                .SetAgeMonths("ageMonths teste")
                .SetSize("size teste")
                .SetDescription("description teste")
                .Build();
        }

        private Pet PetBuilderForTest()
        {
            return new PetBuilder()
                .SetId(1)
                .SetUserId(1)
                .SetName("name")
                .SetBreed("breed")
                .SetSpecie("specie")
                .SetAgeYears("ageYears")
                .SetAgeMonths("ageYears")
                .SetSize("size")
                .SetDescription("description")
                .Build();
        }
    }
}
