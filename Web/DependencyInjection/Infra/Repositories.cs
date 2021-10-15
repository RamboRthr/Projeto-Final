using Domain.Interfaces;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Web.DependencyInjection.Infra
{
    [ExcludeFromCodeCoverage]
    public static class Repositories
    {
        public static void AddRepositoriesDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
        }
    }
}
