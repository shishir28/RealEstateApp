using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Application;
using RealEstate.Persistence;

namespace RealEstateAPI
{


    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            var environmentName = builder.Environment?.EnvironmentName;

            var issuer = @"http://localhost/";
            var audience = @"http://localhost/";

            // dont register database for test set up like integration test or fitness function
            if (environmentName != "Test")
                builder.Services.AddPersistenceServices(builder.Configuration);

            if (environmentName == "Test")
            {
                builder.Configuration["JWT:Issuer"] = issuer;
                builder.Configuration["JWT:Audience"] = audience;
            }


            builder.Services.AddHealthChecks();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   //ValidateIssuerSigningKey = true,
                   ValidAudience = builder.Configuration["JWT:Audience"],
                   ValidIssuer = builder.Configuration["JWT:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
               };
           });
            //Learn more about configuring Swagger / OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            AddSwagger(builder.Services);
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Real.API v1"));
            }
            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            //app.UseRouting();
            app.UseAuthentication();
            // app.UseCustomExceptionHandler();
            app.UseCors("Open");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapHealthChecks("/healthz");
            app.MapControllers();
            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "RealEstateAPI", Version = "v1" });
            });
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var dbContext = services.GetRequiredService<RealEstateDbContext>();
                if (dbContext != null)
                {
                    logger.LogInformation("Dropping database associated with context {DbContextName}", nameof(RealEstateDbContext));
                    await dbContext.Database.EnsureDeletedAsync();
                    logger.LogInformation("Dropped database associated with context {DbContextName}", nameof(RealEstateDbContext));
                    // Dont migrate DB if relational . Call to migrate should be avoided for InMemoryDatabase
                    // 
                    if (dbContext.Database.IsSqlServer())
                    {
                        await dbContext.Database.MigrateAsync();
                        new RealEstateDbContextSeed().SeedAsync(dbContext).Wait();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while dropping the database");
            }
        }
    }
}
