using Application.Models.UserModels;
using Application.Security;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        public IConfiguration Configuration { get; }

        public LoginService(IUserRepository userRepository,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            Configuration = configuration;
        }

        public async Task<UserLoginResponseModel> AuthenticateUser(UserLoginRequestModel loginRequestModel)
        {
            var user = await _userRepository.GetUserByEmailAndPassword(loginRequestModel.Email, loginRequestModel.Password);

            if (user == null)
            {
                return new UserLoginResponseModel
                {
                    Message = "Usuário não cadastrado!"
                };
            }
            else
            {
                var identity = new ClaimsIdentity(
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, user.Name)
                        }
                    );

                var createDate = DateTime.Now;
                var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(token, user);
            }

        }

        private string CreateToken(ClaimsIdentity identity,
                                   DateTime createDate,
                                   DateTime expirationDate,
                                   JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);

            return token;
        }

        private static UserLoginResponseModel SuccessObject(string token, User user)
        {
            return new UserLoginResponseModel
            {
                Token = token,
                UserId = user.Id.ToString(),
                Message = "Usuário Autenticado com Sucesso!"
            };
        }
    }
}
