using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Persistence.Repositories;
using RealEstate.Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RealEstate.API.FitnessTests.Performance.PerformanceTests;
using RealEstate.API.FitnessTests.ContractTests;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Entities;

namespace RealEstate.API.FitnessTests;

internal static class StartupExtensions
{
    internal static void AddPersistenceServices(this IServiceCollection services)
    {
        services.RemoveAll(typeof(DbContextOptions<RealEstateDbContext>));
        //Each time, we will have unique DB name so that not shared across tests
        //services.AddDbContext<RealEstateDbContext>(options =>
        //         options.UseSqlite("Data Source=:memory:"));
        var databaseName = $"RealEstateAPIInMemoryDb-{Guid.NewGuid()}";

        services.AddDbContext<RealEstateDbContext>(options =>
                 options.UseInMemoryDatabase(databaseName));
        
        services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<RealEstateDbContext>()
        .AddDefaultTokenProviders(); ;

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookmarkRepository, BookmarkRepository>();
        services.AddScoped<IPerformanceMesaure, PerformanceMesaure>();
        services.AddScoped<IDataContractValidator, DataContractValidator>();
        Resolver.RegisterServices(services);
    }
}

