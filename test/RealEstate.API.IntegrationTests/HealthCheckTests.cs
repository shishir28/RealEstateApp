using Microsoft.AspNetCore.Mvc.Testing;

namespace RealEstate.API.IntegrationTests;

public class HealthCheckTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HealthCheckTests(WebApplicationFactory<Program> factory)
    {
        factory.ClientOptions.BaseAddress = new Uri("http://localhost");
        _factory = factory;
    }

    [Fact]
    public async Task HealthCheck_ReturnsOk()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/healthz");
        response.EnsureSuccessStatusCode();
    }
}
