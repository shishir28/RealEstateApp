using RealEstate.API.IntegrationTests.Models;
using RealEstate.API.IntegrationTests.TestHelpers;
using Shouldly;

namespace RealEstate.API.IntegrationTests.Controllers;
public class CategoryControllerTests : BaseControllerTests
{
    public CategoryControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task Get_All_Returns_Expected_Array_Of_Categories()
    {
        var client = await CreateWebClientForAuthenticatedUser();
        var categories = await client.GetJsonAsync<List<Category>>("/category");
        categories!.Count.ShouldBe(4);
    }
}
