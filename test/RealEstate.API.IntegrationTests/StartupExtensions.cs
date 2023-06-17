using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Persistence.Repositories;
using RealEstate.Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RealEstate.API.IntegrationTests
{
    internal static class StartupExtensions
    {
        internal static void AddPersistenceServices(this IServiceCollection services)
        {
            services.RemoveAll(typeof(DbContextOptions<RealEstateDbContext>));

            services.AddDbContext<RealEstateDbContext>(options =>
            options.UseInMemoryDatabase("RealEstateAPIInMemoryDb"));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
        }

    }
}
