using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.API.IntegrationTests.Models;
using RealEstate.API.IntegrationTests.TestHelpers.Serialization;
using RealEstate.Persistence;

namespace RealEstate.API.IntegrationTests.Controllers;

public class BaseControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    protected readonly CustomWebApplicationFactory<Program> _factory;

    internal BaseControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        factory.ClientOptions.BaseAddress = new Uri("http://localhost");
        _factory = factory;
        SetupInitialData();
    }

    protected void SetupInitialData()
    {
        var serviceProvider = _factory.Services.GetService<IServiceProvider>();
        using var scope = serviceProvider!.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<RealEstateDbContext>();
        GenesisDataState.ResetDatabaseState(dbContext).Wait();
    }

    protected HttpClient CreateHttpClient() => _factory.CreateClient();

    protected async Task<HttpClient> CreateWebClientForAuthenticatedUser()
    {
        //var accessToken = await LoginDefaultUserAsync();
        var client = CreateHttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(FakeAuthenticationHandler.AuthScheme);
        return client;
    }

    protected async Task<string> LoginDefaultUserAsync()
    {
        var client = CreateHttpClient();
        var defaultUser = GenesisDataState.GetUsers().FirstOrDefault(x => x.Email == "andrew@email.com");

        var loginUser = new Login
        {
            Email = defaultUser!.Email,
            Password = "And@1234"
        };
        var json = JsonSerializer.Serialize(loginUser, JsonSerializerHelper.DefaultSerializationOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/user/login", content);
        var result = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<Token>(result, JsonSerializerHelper.DefaultDeserializationOptions);
        return tokenResponse!.AccessToken;
    }
}
