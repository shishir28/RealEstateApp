using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.API.FitnessTests.Models;
using RealEstate.API.FitnessTests.TestHelpers.Serialization;
using RealEstate.Persistence;

namespace RealEstate.API.FitnessTests.Fixtures
{
    public class BaseRestFixture : IClassFixture<FitnessWebApplicationFactory<Program>>
    {
        protected readonly FitnessWebApplicationFactory<Program> _factory;

        internal BaseRestFixture(FitnessWebApplicationFactory<Program> factory)
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

        protected HttpClient CreateWebClientForAuthenticatedUser()
        {
            //var accessToken = LoginDefaultUser();
            var client = CreateHttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(FakeAuthenticationHandler.AuthScheme);
            return client;
        }

        protected string LoginDefaultUser()
        {
            var client = CreateHttpClient();
            var defaultUser = GenesisDataState.GetUsers().FirstOrDefault(x => x.Email == "andrew@email.com");

            var loginUser = new Login
            {
                Email = defaultUser!.Email,
                Password = defaultUser!.PasswordHash
            };
            var json = JsonSerializer.Serialize(loginUser, JsonSerializerHelper.DefaultSerializationOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/user/login", content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var tokenResponse = JsonSerializer.Deserialize<Token>(result, JsonSerializerHelper.DefaultDeserializationOptions);
            return tokenResponse!.AccessToken;
        }
    }
}
