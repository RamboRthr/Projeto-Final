using Application.Models.UserModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserResponseModel>()
                .ReverseMap();
        }
    }
}
