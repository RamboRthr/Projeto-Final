using Application.Models.UserModels;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Builder;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPetRepository _petRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IPetRepository petRepository,
                           IPhotoRepository photoRepository,
                           IPhotoService photoService,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _petRepository = petRepository;
            _photoRepository = photoRepository;
            _photoService = photoService;
            _mapper = mapper;
        }

        public async Task CreateUser(UserRequestModel userRequestModel)
        {
            var entity = userRequestModel.ConvertToUserEntity();

            await _userRepository.Create(entity);

            await _userRepository.Save();
        }

        public async Task UpdateUser(UserUpdateRequestModel userUpdateRequestModel)
        {
            var updatedUser = userUpdateRequestModel.ConvertToUserEntity();

            var alredyRegisteredUser = await _userRepository.GetUserById(updatedUser.Id);

            alredyRegisteredUser.UpdateUser(updatedUser);

            _userRepository.Update(alredyRegisteredUser);

            await _userRepository.Save();
        }

        public async Task DeleteUser(int userId)
        {
            await DeleteFilePhotosFromUserPets(userId);

            await _userRepository.Delete(userId);

            await _userRepository.Save();
        }

        public async Task<UserResponseModel> GetUserById(int userId)
        {
            var user = await _userRepository.GetById(userId);

            var pets = await _petRepository.GetPetsByUserId(user.Id);

            var petsWithPhoto = await AddPhotoToPetEntity(pets);

            var userWithHisPets = ConvertToUserEntity(user, petsWithPhoto);

            return _mapper.Map<UserResponseModel>(userWithHisPets);
        }

        public async Task<UserResponseModel> VerifyIfUserCpfAlredyExists(string userCpf)
        {
            var result = await _userRepository.VerifyIfUserCpfAlredyExists(userCpf);

            return _mapper.Map<UserResponseModel>(result);
        }

        public async Task<UserResponseModel> VerifyIfUserEmailAlredyExists(string userEmail)
        {
            var result = await _userRepository.VerifyIfUserEmailAlredyExists(userEmail);

            return _mapper.Map<UserResponseModel>(result);
        }

        private static User ConvertToUserEntity(User user, List<Pet> pets)
        {
            return new UserBuilder()
                .SetId(user.Id)
                .SetName(user.Name)
                .SetSurname(user.Surname)
                .SetCpf(user.Cpf)
                .SetEmail(user.Email)
                .SetPhone(user.Phone)
                .SetStreet(user.Street)
                .SetHouseNumber(user.HouseNumber)
                .SetDistrict(user.District)
                .SetCep(user.Cep)
                .SetBirthDate(user.BirthDate)
                .SetPassword(user.Password)
                .SetPets(pets)
                .Build();
        }

        private async Task<List<Pet>> AddPhotoToPetEntity(List<Pet> pets)
        {
            var petsWithPhoto = new List<Pet>();

            foreach (var pet in pets)
            {
                var photo = await _photoRepository.GetPhotoByPetId(pet.Id);

                var newPetWithPhoto = new PetBuilder()
                   .SetId(pet.Id)
                   .SetName(pet.Name)
                   .SetUserId(pet.UserId)
                   .SetBreed(pet.Breed)
                   .SetSpecie(pet.Specie)
                   .SetAgeYears(pet.AgeYears)
                   .SetAgeMonths(pet.AgeMonths)
                   .SetSize(pet.Size)
                   .SetDescription(pet.Description)
                   .SetPhoto(photo)
                   .Build();

                petsWithPhoto.Add(newPetWithPhoto);
            }

            return petsWithPhoto;
        }

        private async Task DeleteFilePhotosFromUserPets(int userId)
        {
            var petsFromDeletedUser = await _petRepository.GetPetsByUserId(userId);

            foreach (var pet in petsFromDeletedUser)
            {
                var photo = await _photoRepository.GetPhotoByPetId(pet.Id);

                await _photoService.DeletePhotoFile(photo.PhotoPath, photo.Id);
            }
        }
    }
}
