using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Web.DependencyInjection.Application
{
    [ExcludeFromCodeCoverage]
    internal class Services
    {
        public void AddServicesDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPhotoService, PhotoService>();
        }
    }
}
