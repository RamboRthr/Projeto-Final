using Application.Models.PhotoModels;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Builder;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PhotoService(IPhotoRepository photoRepository, IPetRepository petRepository, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task CreatePhotoRegister(string photoPath, int petId)
        {
            var entity = ConvertToPhotoEntity(petId, photoPath);

            await _photoRepository.Create(entity);

            await _photoRepository.Save();
        }

        public async Task<string> SavePhotoFile(string allPetsPhotosFolderPath,
                                                IFormFile photoFile,
                                                int petId)
        {

            if (!Directory.Exists(allPetsPhotosFolderPath))
            {
                Directory.CreateDirectory(allPetsPhotosFolderPath);
            }

            var petOwnerOfPhoto = await _petRepository.GetById(petId);

            var specificPetPhotosFolderPath = allPetsPhotosFolderPath + "\\Pet.Name_" + $"{petOwnerOfPhoto.Name}" + "_Pet.Id_" + $"{petOwnerOfPhoto.Id}\\".ToString();

            if (!Directory.Exists(specificPetPhotosFolderPath))
            {
                Directory.CreateDirectory(specificPetPhotosFolderPath);
            }

            CreateFile(specificPetPhotosFolderPath, photoFile.FileName, photoFile);

            var photoFilePath = specificPetPhotosFolderPath + $"\\{photoFile.FileName}";

            return photoFilePath;
        }

        public async Task<PhotoResponseModel> GetPhotoById(int photoId)
        {
            var result = await _photoRepository.GetById(photoId);
            return _mapper.Map<PhotoResponseModel>(result);
        }

        public async Task<PhotoResponseModel> GetPhotoByPetId(int petId)
        {
            var result = await _photoRepository.GetPhotoByPetId(petId);

            return _mapper.Map<PhotoResponseModel>(result);
        }

        public async Task DeletePhoto(int photoId, string photoPath)
        {
            await DeletePhotoFile(photoPath, photoId);

            await _photoRepository.Delete(photoId);

            await _photoRepository.Save();
        }

        private static void CreateFile(string folderPath, string fileName, IFormFile photoFile)
        {
            FileStream fileStream = File.Create(folderPath + fileName);
            photoFile.CopyTo(fileStream);
            fileStream.Flush();
            fileStream.Dispose();
        }

        private async Task DeletePhotoFile(string photoPath, int photoId)
        {
            File.Delete(photoPath);

            var specificPetFolder = Path.GetDirectoryName(photoPath);

            var specificPetFolderPhotos = Directory.EnumerateFileSystemEntries(specificPetFolder).ToList();

            if (!specificPetFolderPhotos.Any())
            {
                var photo = await _photoRepository.GetById(photoId);

                await _photoRepository.DeletePhotoRecordFromPet(photo.PetId);

                Directory.Delete(specificPetFolder);
            }
        }

        private static Photo ConvertToPhotoEntity(int petId, string photoPath)
        {
            return new PhotoBuilder()
                .SetPetId(petId)
                .SetPhotoPath(photoPath)
                .Build();
        }
    }
}
