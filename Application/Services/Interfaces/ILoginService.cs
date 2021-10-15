using Application.Models.UserModels;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserLoginResponseModel> AuthenticateUser(UserLoginRequestModel loginRequestModel);
    }
}
