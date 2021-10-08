using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Projeto_Final.Models;

namespace Projeto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signManager;
        private readonly ILogger<UsersController> _logger;
        private readonly JWTConfig _jwtConfig;
        public UsersController(ILogger<UsersController> logger, SignInManager<Users> signManager, UserManager<Users> userManager, IOptions<JWTConfig> jWTConfig)
        {
            _jwtConfig = jWTConfig.Value;
            _signManager = signManager;
            _userManager = userManager;
            _logger = logger;
        }
        [HttpPost("RegisterUser")]
        public async Task<object> RegisterModel([FromBody] RegisterModel model)
        {
            try
            {
                var user = new Users()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                var result = await (_userManager.CreateAsync(user, model.Password));
                if (result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Ok, "User Has Been Registered", null));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "", result.Errors.Select(x => (x.Description).ToArray())));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetAllUser")]
        public async Task<object> GetAllUser()
        {
            try
            {
                var users = _userManager.Users.Select(x => new UserDTO(x.FullName, x.Email, x.UserName,x.DateCreated));
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", users));


            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [HttpPost("Login")]
        public async Task<object> Login([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        var appUser = await _userManager.FindByEmailAsync(model.Email);
                        var user = new UserDTO(appUser.FullName, appUser.Email, appUser.UserName, appUser.DateCreated);
                        user.Token = GenerateToken(appUser);
                        return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", user));
                    }
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "invalid Email or password", null));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        private string GenerateToken(Users user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) }
                ),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
