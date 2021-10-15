using Application.Models.UserModels;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IPhotoService _photoService;
        private readonly IPetService _petService;

        public UserController(IUserService userService,
                              IPhotoService photoService,
                              IPetService petService)
        {
            _userService = userService;
            _photoService = photoService;
            _petService = petService;
        }

        [Authorize("Bearer")]
        [Route("get-user-by-{userId}")]
        [HttpGet]
        public async Task<ActionResult> GetUserById([FromRoute] int userId)
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

        [Authorize("Bearer")]
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
        public async Task<ActionResult> Create([FromRoute] UserRequestModel requestModel)
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

        [Authorize("Bearer")]
        [Route("update-user")]
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromRoute] UserUpdateRequestModel updateRequestModel)
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

        [Authorize("Bearer")]
        [Route("delete-user-by-{userId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromRoute] int userId)
        {
            if (await _userService.GetUserById(userId) == null)
            {
                return NotFound($"Não existe um User com Id:{userId} na base de dados que possa ser excluído.");
            }

            try
            {
                await _userService.DeleteUser(userId);

                var petsFromDeletedUser = await _petService.GetPetsByUserId(userId);

                foreach (var pet in petsFromDeletedUser)
                {
                    var photo = await _photoService.GetPhotoByPetId(pet.Id);

                    await _photoService.DeletePhoto(photo.Id, photo.PhotoPath);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
