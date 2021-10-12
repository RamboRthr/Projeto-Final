using Application.Models.UserModels;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("get-user-by-id")]
        [HttpGet]
        public async Task<ActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _userService.GetUserById(userId);

                if (user == null)
                {
                    return NotFound($"Não existe um Usuário com o Id:{userId} na Base de dados.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("get-all-users")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("create-user")]
        [HttpPost]
        public async Task<ActionResult> Create(UserRequestModel requestModel)
        {
            if (await _userService.VerifyIfUserCpfAlredyExists(requestModel.Cpf) != null)
            {
                return BadRequest($"Já existe um Usuário cadastrado com o Cpf: {requestModel.Cpf}");
            }

            if (await _userService.VerifyIfUserEmailAlredyExists(requestModel.Email) != null)
            {
                return BadRequest($"Já existe um Usuário cadastrado com o Email: {requestModel.Email}");
            }

            try
            {
                await _userService.CreateUser(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("update-user")]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserUpdateRequestModel updateRequestModel)
        {
            if (await _userService.GetUserById(updateRequestModel.Id) == null)
            {
                return NotFound($"Não existe um User com Id:{updateRequestModel.Id} na base de dados.");
            }

            try
            {
                await _userService.UpdateUser(updateRequestModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-user-by-id")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            if (await _userService.GetUserById(userId) == null)
            {
                return NotFound($"Não existe um User com Id:{userId} na base de dados que possa ser excluído.");
            }

            try
            {
                await _userService.DeleteUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
