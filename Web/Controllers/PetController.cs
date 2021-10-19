using Application.Models.PetModels;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("pet")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IUserService _userService;

        public PetController(IPetService petService, IUserService userService)
        {
            _petService = petService;
            _userService = userService;
        }

        [Authorize("Bearer")]
        [Route("create-pet")]
        [HttpPost]
        public async Task<ActionResult> CreatePet(PetRequestModel requestModel)
        {
            var user = await _userService.GetUserById(requestModel.UserId);

            if (user == null)
            {
                return NotFound($"Não existe um Usuário com o Id:{requestModel.UserId} na Base de dados. Verifique e tente novamente.");
            }

            if (await _petService.VerifyIfPetAlredyExists(requestModel) != null)
            {
                return BadRequest("Este Pet já existe na base de dados");
            }

            try
            {
                await _petService.CreatePet(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [Route("update-pet")]
        [HttpPut]
        public async Task<ActionResult> UpdatePet(PetUpdateRequestModel requestModel)
        {
            if (await _petService.GetPetById(requestModel.Id) == null)
            {
                return NotFound($"Não existe um Pet com Id:{requestModel.Id} na base de dados.");
            }

            try
            {
                await _petService.UpdatePet(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [Route("delete-pet-by-{petId}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePet([FromRoute] int petId)
        {
            if (await _petService.GetPetById(petId) == null)
            {
                return NotFound($"Não existe um Pet com Id:{petId} na base de dados que possa ser excluído.");
            }

            try
            {
                await _petService.DeletePet(petId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("get-all-pets")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _petService.GetAllPets());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [Route("get-pet-by-{petId}")]
        [HttpGet]
        public async Task<ActionResult> GetPetById([FromRoute] int petId)
        {
            try
            {
                var pet = await _petService.GetPetById(petId);

                if (pet == null)
                {
                    return NotFound($"Não existe um Pet com o Id:{petId} na Base de dados.");
                }

                return Ok(pet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [Route("get-pets-by-{userId}")]
        [HttpGet]
        public async Task<ActionResult> GetPetsByUserId([FromRoute] int userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound($"Não existe um Usuário com o Id:{userId} na Base de dados.");
            }

            try
            {
                var petsFromUser = await _petService.GetPetsByUserId(userId);

                if (petsFromUser.Count < 1)
                {
                    return NotFound($"O usuário '{user.Name}' ainda não tem nenhum Pet cadastrado em seu nome.");
                }

                return Ok(petsFromUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [Route("confirm-pet-adoption-by-{petId}")]
        [HttpPut]
        public async Task<ActionResult> ConfirmPetAdoption([FromRoute] int petId)
        {
            if (await _petService.GetPetById(petId) == null)
            {
                return NotFound($"Não existe um Pet com Id:{petId} na base de dados que possa ter o status de adoção alterado.");
            }

            try
            {
                await _petService.ConfirmPetAdoption(petId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
