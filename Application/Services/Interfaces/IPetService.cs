using Application.Models.PetModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPetService
    {
        Task CreatePet(PetRequestModel petRequestModel);
        Task UpdatePet(PetUpdateRequestModel petRequestModel);
        Task DeletePet(int petId);
        Task<List<PetResponseModel>> GetAllPets();
        Task<PetResponseModel> GetPetById(int petId);
        Task<List<PetResponseModel>> GetPetsByUserId(int userId);
        Task<PetResponseModel> VerifyIfPetAlredyExists(PetRequestModel petRequestModel);
        Task ConfirmPetAdoption(int petId);
    }
}
