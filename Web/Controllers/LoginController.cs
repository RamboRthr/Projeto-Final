using Application.Models.UserModels;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [Route("authenticate-user")]
        [HttpPost]
        public async Task<ActionResult> AuthenticateUser([FromRoute] UserLoginRequestModel loginRequestModel)
        {
            try
            {
                var user = await _loginService.AuthenticateUser(loginRequestModel);

                if (user == null)
                {
                    return NotFound($"Não existe um Usuário com o Email:{loginRequestModel.Email}. Considere se cadastrar no nosso site!");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
