using Application.Models.PhotoModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPhotoService
    {
        Task CreatePhotoRegister(string photoPath, int petId);
        Task<string> SavePhotoFile(string allPetsPhotosFolderPath, IFormFile photoFile, int petId);
        Task DeletePhoto(int photoId, string photoPath);
        Task DeletePhotoFile(string photoPath, int photoId);
    }
}
