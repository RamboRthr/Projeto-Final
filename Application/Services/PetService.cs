using Application.Models.PetModels;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetService(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<PetResponseModel>> GetAllPets()
        {
            var userEntitiesList = await _petRepository.GetAll();
            return _mapper.Map<List<PetResponseModel>>(userEntitiesList);
        }

        public async Task CreatePet(PetRequestModel petRequestModel)
        {
            var entity = petRequestModel.ConvertToPetEntity();

            await _petRepository.Create(entity);

            await _petRepository.Save();
        }

        public async Task UpdatePet(PetUpdateRequestModel petRequestModel)
        {
            var updatedPet = petRequestModel.ConvertToPetEntity();

            var alredyRegisteredPet = await _petRepository.GetPetById(updatedPet.Id);

            alredyRegisteredPet.UpdatePet(updatedPet);

            _petRepository.Update(alredyRegisteredPet);

            await _petRepository.Save();
        }

        public async Task<PetResponseModel> GetPetById(int id)
        {
            var result = await _petRepository.GetById(id);
            return _mapper.Map<PetResponseModel>(result);
        }

        public async Task<List<PetResponseModel>> GetPetsByUserId(int id)
        {
            var result = await _petRepository.GetPetsByUserId(id);
            return _mapper.Map<List<PetResponseModel>>(result);
        }

        public async Task<PetResponseModel> VerifyIfPetAlredyExists(PetRequestModel petRequestModel)
        {
            var entity = petRequestModel.ConvertToPetEntity();

            var result = await _petRepository.VerifyIfPetAlredyExists(entity);

            return _mapper.Map<PetResponseModel>(result);

        }

        public async Task ConfirmPetAdoption(int id)
        {
            var petToUpdateAdoption = await _petRepository.GetById(id);

            petToUpdateAdoption.ConfirmAdoption();

            _petRepository.Update(petToUpdateAdoption);

            await _petRepository.Save();
        }

        public async Task DeletePet(int id)
        {
            await _petRepository.Delete(id);

            await _petRepository.Save();
        }
    }
}
