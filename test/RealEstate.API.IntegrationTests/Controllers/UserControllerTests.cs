using RealEstate.API.IntegrationTests.Models;
using RealEstate.API.IntegrationTests.TestHelpers;


namespace RealEstate.API.IntegrationTests.Controllers
{
    public class UserControllerTests : BaseControllerTests
    {
        public UserControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

        }

        [Fact]
        public async Task Post_RegisterWithValidRequest_IsSuccessful()
        {
            var client = CreateHttpClient();
            var registerUser = new Register
            {
                Email = "john.doe@email.com",
                Password = "P@ssw0rd",
                Phone = "1234567890"
            };          
            var response = await client.PostJsonAsync("/user/register", registerUser);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_LoginWithValidRequest_IsSuccessful()
        {
            var accessToken = await LoginDefaultUserAsync();
            Assert.NotEmpty(accessToken);
        }
    }
}

