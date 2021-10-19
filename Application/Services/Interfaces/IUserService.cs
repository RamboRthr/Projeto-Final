using Application.Models.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserRequestModel userRequestModel);
        Task UpdateUser(UserUpdateRequestModel userUpdateRequestModel);
        Task DeleteUser(int userId);
        Task<UserResponseModel> GetUserById(int userId);
        Task<UserResponseModel> VerifyIfUserCpfAlredyExists(string userCpf);
        Task<UserResponseModel> VerifyIfUserEmailAlredyExists(string userEmail);
    }
}
