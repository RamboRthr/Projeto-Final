using Domain.Interfaces;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Web.DependencyInjection.Infra
{
    [ExcludeFromCodeCoverage]
    internal class Repositories
    {
        public void AddRepositoriesDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
        }
    }
}
