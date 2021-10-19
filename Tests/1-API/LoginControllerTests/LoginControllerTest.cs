using Application.Models.UserModels;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Web.Controllers;
using Xunit;

namespace Tests._1_API.LoginControllerTests
{
    public class LoginControllerTest
    {
        private readonly ILoginService _loginService;
        private readonly LoginController _loginController;
        private readonly HttpContext _httpContext;

        public LoginControllerTest()
        {
            _loginService = Substitute.For<ILoginService>();
            _httpContext = Substitute.For<HttpContext>();

            _loginController = new LoginController(_loginService)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };
        }

        [Fact]
        public async Task Should_Return_NotFound_If_Not_ResponseModel()
        {
            var requestModel = new UserLoginRequestModel()
            {
                Email = "test@test.com",
                Password = "1234567"
            };

            _loginService.AuthenticateUser(Arg.Any<UserLoginRequestModel>()).Returns((UserLoginResponseModel)null);

            var response = await _loginController.AuthenticateUser(requestModel);

            var notFound = Assert.IsType<NotFoundObjectResult>(response);

            Assert.NotNull(notFound);
            Assert.Equal(404, notFound.StatusCode);
        }
    }
}
