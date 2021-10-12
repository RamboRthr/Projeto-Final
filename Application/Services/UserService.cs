using Application.Models.UserModels;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserResponseModel>> GetAllUsers()
        {
            var userEntitiesList = await _userRepository.GetAll();
            return _mapper.Map<List<UserResponseModel>>(userEntitiesList);
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

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var result = await _userRepository.GetById(id);
            return _mapper.Map<UserResponseModel>(result);
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

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
            await _userRepository.Save();
        }
    }
}
