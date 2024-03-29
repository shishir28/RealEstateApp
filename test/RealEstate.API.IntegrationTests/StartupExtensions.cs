﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Persistence.Repositories;
using RealEstate.Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RealEstate.API.IntegrationTests;

internal static class StartupExtensions
{
    internal static void AddPersistenceServices(this IServiceCollection services)
    {

        services.RemoveAll(typeof(IdentityDbContext<ApplicationUser>));

        //Each time, we will have unique DB name so that not shared across tests
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
    }
}
