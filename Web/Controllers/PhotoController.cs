using Application.Models.PhotoModels;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("photo")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPhotoService _photoService;
        private readonly IPetService _petService;

        public PhotoController(IPhotoService photoService, IWebHostEnvironment webHostEnvironment, IPetService petService)
        {
            _photoService = photoService;
            _webHostEnvironment = webHostEnvironment;
            _petService = petService;
        }

        [Authorize("Bearer")]
        [Route("create-photo")]
        [HttpPost]
        public async Task<ActionResult> CreatePhoto([FromForm] PhotoRequestModel requestModel, IFormFile photoFile)
        {
            if (photoFile == null || photoFile.Length == 0)
            {
                return BadRequest("Um arquivo precisa ser informado.");
            }

            var permitedExtensions = new List<string> { ".jpg", ".png", ".jpeg" };

            var fileExtension = Path.GetExtension(photoFile.FileName).ToLowerInvariant();

            if (!permitedExtensions.Contains(fileExtension))
            {
                return BadRequest("Formato de arquivo inválido.");
            }

            var pet = await _petService.GetPetById(requestModel.PetId);

            if (pet == null)
            {
                return NotFound($"Não existe um Pet com o Id:{requestModel.PetId} na Base de dados. Verifique e tente novamente.");
            }

            if (pet.PetPhoto.PhotoPath.Length > 0)
            {
                await _photoService.DeletePhotoFile(pet.PetPhoto.PhotoPath, pet.PetPhoto.Id);
            }

            string petPhotosFolderPath = _webHostEnvironment.WebRootPath + "\\PetUploadedPhotos\\";

            try
            {
                var photoFilePath = await _photoService.SavePhotoFile(petPhotosFolderPath, photoFile, requestModel.PetId);

                await _photoService.CreatePhotoRegister(photoFilePath, requestModel.PetId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [Route("delete-photo-by-{petId}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePhoto([FromRoute] int petId)
        {
            var pet = await _petService.GetPetById(petId);

            if (pet == null)
            {
                return NotFound($"Não existe um Pet com ID:{petId} na Base de dados.");
            }
            if (pet.PetPhoto == null)
            {
                return NotFound($"O Pet {pet.Name} não tem uma Foto cadastrada na Base de dados.");
            }
            try
            {
                await _photoService.DeletePhoto(pet.PetPhoto.Id, pet.PetPhoto.PhotoPath);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
