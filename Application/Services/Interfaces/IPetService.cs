using Application.Models.PetModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPetService
    {
        Task<List<PetResponseModel>> GetAllPets();
        Task CreatePet(PetRequestModel petRequestModel);
        Task UpdatePet(PetUpdateRequestModel petRequestModel);
        Task<PetResponseModel> GetPetById(int id);
        Task<List<PetResponseModel>> GetPetsByUserId(int id);
        Task<PetResponseModel> VerifyIfPetAlredyExists(PetRequestModel petRequestModel);
        Task ConfirmPetAdoption(int id);
        Task DeletePet(int id);
    }
}
