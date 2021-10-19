using Application.Models.PhotoModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class PhotoMapper : Profile
    {
        public PhotoMapper()
        {
            CreateMap<Photo, PhotoResponseModel>()
                .ReverseMap();
        }
    }
}
