using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Controllers;
using NSubstitute;
using Xunit;
using Application.Models.PetModels;
using Application.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Application.Models.PhotoModels;

namespace Tests._1_API.PetControllerTests
{
    public class CreatePet_PetControllerTest
    {
        private readonly IPetService _petService;
        private readonly IUserService _userService;
        private readonly HttpContext _httpContext;
        private readonly PetController _petController;
        PetRequestModel requestModel;
        UserResponseModel userResponseModel;

        public CreatePet_PetControllerTest()
        {
            _petService = Substitute.For<IPetService>();
            _userService = Substitute.For<IUserService>();
            _httpContext = Substitute.For<HttpContext>();

            _petController = new PetController(_petService, _userService)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            requestModel = new PetRequestModel
            {
                Name = "NomeTeste",
                UserId = 0,
                Specie = "especieTeste",
                Breed = "racaTeste",
                AgeYears = "idadeTeste",
                AgeMonths = "idadeTeste",
                Size = "tamanhoTeste",
                Description = "descricaoTeste"


            };

            userResponseModel = new UserResponseModel
            {
                Name = "NomeTeste",
                Surname = "",
                Cpf = "especieTeste",
                Email = "racaTeste",
                Phone = "idadeTeste",
                Street = "idadeTeste",
                HouseNumber = "tamanhoTeste",
                District = "descricaoTeste",
                Id = 0,
                Pets = new List<PetResponseModel>(),
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime()


            };
        }


        [Fact]
        public async Task Deve_Retornar_NotFound_Se_UserNull()
        { 
            _userService.GetUserById(Arg.Any<int>()).Returns((UserResponseModel)null);

            //ACT(AGIR)
            var response = await _petController.CreatePet(requestModel);

            var notFound = Assert.IsType<NotFoundObjectResult>(response);

            Assert.NotNull(notFound);
            Assert.Equal(404, notFound.StatusCode);
        }

        [Fact]
        public async Task Deve_Retornar_BadRequest_Se_PetJaExiste()
        {
            try
            {
                _petService.When(s => s.VerifyIfPetAlredyExists(Arg.Any<PetRequestModel>()))
                .Do(s => { throw new Exception(); });
            }
            catch (Exception)
            {
                var response = await _petController.CreatePet(requestModel);

                var badRequest = Assert.IsType<BadRequestObjectResult>(response);

                Assert.NotNull(badRequest);
                Assert.Equal(400, badRequest.StatusCode);
                throw;
            }
        }

        [Fact]
        public async Task Deve_Retornar_Ok_Se_PetCriado()
        {
            _userService.GetUserById(Arg.Any<int>()).Returns(userResponseModel);
            _petService.VerifyIfPetAlredyExists(Arg.Any<PetRequestModel>()).Returns((PetResponseModel)null);
            await _petService.CreatePet(Arg.Any<PetRequestModel>());

            var response = await _petController.CreatePet(requestModel);

            var okResponse = Assert.IsType<OkResult>(response);

            Assert.NotNull(okResponse);
            Assert.Equal(200, okResponse.StatusCode);
        }
    }
}
