using Application.Models.PetModels;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Builder;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public PetService(IPetRepository petRepository,
                          IUserRepository userRepository,
                          IPhotoRepository photoRepository,
                          IMapper mapper)
        {
            _petRepository = petRepository;
            _userRepository = userRepository;
            _photoRepository = photoRepository;
            _mapper = mapper;
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

        public async Task DeletePet(int petId)
        {
            await _petRepository.Delete(petId);

            await _petRepository.Save();
        }

        public async Task<List<PetResponseModel>> GetAllPets()
        {
            var pets = await _petRepository.GetAll();

            var petsWithPhotoAndUser = await AddUsersAndPhotosToPets(pets);

            return _mapper.Map<List<PetResponseModel>>(petsWithPhotoAndUser);
        }

        public async Task<PetResponseModel> GetPetById(int petId)
        {
            var pet = await _petRepository.GetById(petId);

            if (pet == null)
            {
                return _mapper.Map<PetResponseModel>(pet);
            }

            var user = await _userRepository.GetUserById(pet.UserId);
            var photo = await _photoRepository.GetPhotoByPetId(pet.Id);

            var petWithUserAndPhoto = ConvertToPetEntity(pet, user, photo);

            return _mapper.Map<PetResponseModel>(petWithUserAndPhoto);
        }

        public async Task<List<PetResponseModel>> GetPetsByUserId(int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            var listOfPets = await _petRepository.GetPetsByUserId(userId);

            var listOfPetsWithUserAndPhoto = new List<Pet>();

            foreach (var pet in listOfPets)
            {
                var photo = await _photoRepository.GetPhotoByPetId(pet.Id);
                var petWithUserAndPhoto = ConvertToPetEntity(pet, user, photo);

                listOfPetsWithUserAndPhoto.Add(petWithUserAndPhoto);
            }

            return _mapper.Map<List<PetResponseModel>>(listOfPetsWithUserAndPhoto);
        }

        public async Task<PetResponseModel> VerifyIfPetAlredyExists(PetRequestModel petRequestModel)
        {
            var entity = petRequestModel.ConvertToPetEntity();

            var result = await _petRepository.VerifyIfPetAlredyExists(entity);

            return _mapper.Map<PetResponseModel>(result);
        }

        public async Task ConfirmPetAdoption(int petId)
        {
            var petToUpdateAdoption = await _petRepository.GetById(petId);

            petToUpdateAdoption.ConfirmAdoption();

            _petRepository.Update(petToUpdateAdoption);

            await _petRepository.Save();
        }

        private static Pet ConvertToPetEntity(Pet pet, User user, Photo photo)
        {
            return new PetBuilder()
               .SetId(pet.Id)
               .SetName(pet.Name)
               .SetUserId(pet.UserId)
               .SetBreed(pet.Breed)
               .SetSpecie(pet.Specie)
               .SetAgeYears(pet.AgeYears)
               .SetAgeMonths(pet.AgeMonths)
               .SetSize(pet.Size)
               .SetDescription(pet.Description)
               .SetUser(user)
               .SetPhoto(photo)
               .Build();
        }

        private async Task<List<Pet>> AddUsersAndPhotosToPets(List<Pet> pets)
        {
            var petsWithPhotoAndUser = new List<Pet>();

            foreach (var pet in pets)
            {
                var user = await _userRepository.GetUserById(pet.UserId);

                var photo = await _photoRepository.GetPhotoByPetId(pet.Id);

                var newPetWithPhotoAndUser = ConvertToPetEntity(pet, user, photo);

                petsWithPhotoAndUser.Add(newPetWithPhotoAndUser);
            }

            return petsWithPhotoAndUser;
        }
    }
}
