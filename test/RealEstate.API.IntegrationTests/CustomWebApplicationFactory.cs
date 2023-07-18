using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RealEstate.API.IntegrationTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    public string DefaultUserId { get; set; } = "1";
    public CustomWebApplicationFactory()
    {
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureTestServices(services =>
        {
            services.AddPersistenceServices();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = FakeAuthenticationHandler.AuthScheme;
                options.DefaultChallengeScheme = FakeAuthenticationHandler.AuthScheme;
            }).AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>(FakeAuthenticationHandler.AuthScheme, _ => { });
        });
    }
}
