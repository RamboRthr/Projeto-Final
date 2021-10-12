using Application.Models.PhotoModels;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [Route("get-photos-by-pet-id")]
        [HttpGet]
        public async Task<ActionResult> GetPhotosByPetId(int petId)
        {
            var pet = await _petService.GetPetById(petId);

            if (pet == null)
            {
                return NotFound($"Não existe um Pet com o Id:{petId} na Base de dados. Verifique e tente novamente.");
            }

            try
            {
                var petPhotosList = await _photoService.GetPhotosByPetId(petId);

                if (!petPhotosList.Any())
                {
                    return NotFound($"O Pet '{pet.Name}' ainda não tem nenhuma foto cadastrada.");
                }

                return Ok(petPhotosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("create-photo")]
        [HttpPost]
        public async Task<ActionResult> CreatePetPhoto([FromForm] PhotoRequestModel requestModel, IFormFile photoFile)
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

        [Route("delete-photo-by-id")]
        [HttpDelete]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var photo = await _photoService.GetPhotoById(photoId);

            if (photo == null)
            {
                return NotFound($"Não existe Foto com o Id:{photoId} na Base de dados.");
            }

            try
            {
                await _photoService.DeletePhoto(photoId, photo.PhotoPath);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
