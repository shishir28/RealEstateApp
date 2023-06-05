using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Persistence.Repositories;

namespace RealEstate.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RealEstateDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("RealEstateAPIConnectionString"), b => b.MigrationsAssembly("RealEstateAPI")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();

        return services;
    }
}
