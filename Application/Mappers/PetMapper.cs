using Application.Models.PetModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class PetMapper : Profile
    {
        public PetMapper()
        {
            CreateMap<Pet, PetResponseModel>()
                .ReverseMap();
        }
    }
}
