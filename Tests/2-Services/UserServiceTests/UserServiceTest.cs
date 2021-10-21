using Application.Models.UserModels;
using Application.Services;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace Tests._2_Services.UserServiceTests
{
    public class UserServiceTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IPetRepository _petRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _petRepository = Substitute.For<IPetRepository>();
            _photoRepository = Substitute.For<IPhotoRepository>();
            _photoService = Substitute.For<IPhotoService>();
            _mapper = Substitute.For<IMapper>();

            _userService = new UserService(_userRepository, _petRepository, _photoRepository, _photoService, _mapper);
        }

        [Fact]
        public async Task Deveria_Criar_Usuario()
        {
            var requestModel = new UserRequestModel()
            {
                Name = "Name",
                Surname = "Surname",
                Cpf = "cpf",
                Email = "",
                Phone = "phone",
                Street = "street",
                HouseNumber = "houseNumber",
                District = "District",
                Cep = "Cep",
                BirthDate = "Date",
                Password = "Password"
            };

            var entity = requestModel.ConvertToUserEntity();

            _userRepository.Create(Arg.Any<User>()).Returns(entity);

            await _userService.CreateUser(requestModel);

            await _userRepository.Received(1).Create(Arg.Any<User>());
        }
    }
}
