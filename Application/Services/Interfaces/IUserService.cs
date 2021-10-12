using Application.Models.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAllUsers();
        Task CreateUser(UserRequestModel userRequestModel);
        Task UpdateUser(UserUpdateRequestModel userUpdateRequestModel);
        Task<UserResponseModel> GetUserById(int id);
        Task<UserResponseModel> VerifyIfUserCpfAlredyExists(string userCpf);
        Task<UserResponseModel> VerifyIfUserEmailAlredyExists(string userEmail);
        Task DeleteUser(int id);
    }
}
