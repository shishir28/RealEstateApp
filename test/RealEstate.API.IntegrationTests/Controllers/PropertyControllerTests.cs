using RealEstate.API.IntegrationTests.Models;
using RealEstate.API.IntegrationTests.TestHelpers;
using Shouldly;

namespace RealEstate.API.IntegrationTests.Controllers
{
    public class PropertyControllerTests : BaseControllerTests
    {
        public PropertyControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

        }

        [Fact]
        public async Task Get_All_Trending_Properties_Returns_Expected_Properties()
        {
            var client = await CreateWebClientForAuthenticatedUser();
            var properties = await client.GetJsonAsync<List<TrendingProperty>>("/property/trendingproperties");
            properties!.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Get_All_Properties_For_Categories_Returns_Expected_Properties()
        {
            var client = await CreateWebClientForAuthenticatedUser();
            var penthouseCategory = GenesisDataState.GetCategories().FirstOrDefault(x => x.Name == "Penthouse");
            penthouseCategory!.CategoryId.ShouldBe(new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e"));
            var properties = await client.GetJsonAsync<List<PropertyByCategory>>($"/property/propertyList?categoryId={penthouseCategory!.CategoryId}");
            properties!.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Get_All_Properties_For_Search_Returns_Expected_Properties()
        {
            var client = await CreateWebClientForAuthenticatedUser();
            var address = "Trevi Close";
            var properties = await client.GetJsonAsync<List<SearchProperty>>($"/property/searchProperties?address={address}");
            properties!.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Get_Property_For_Id_Returns_Expected_Property()
        {
            var client = await CreateWebClientForAuthenticatedUser();
            var expectedProperty = GenesisDataState.GetProperties().FirstOrDefault(x => x.Name == "Stuning Drift Street");
            expectedProperty!.PropertyId.ShouldBe(new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b10"));
            var currentProperty = await client.GetJsonAsync<PropertyDetail>($"/property/{expectedProperty.PropertyId}");

            currentProperty!.PropertyId.ShouldBe("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b10");
            currentProperty.Name.ShouldBe("Stuning Drift Street");
            currentProperty.ImageUrl.ShouldBe("imagep2.jpg");
            currentProperty.Price.ShouldBe(700000);
            currentProperty.Address.ShouldBe("Drift Street, The Ponds, NSW 2769");
        }

        [Fact]
        public async Task Post_With_Valid_Property_Returns_CreatedResult()
        {
            var client = await CreateWebClientForAuthenticatedUser();
            var hotelCategory = GenesisDataState.GetCategories().FirstOrDefault(x => x.Name == "Hotel");

            var propertyToAdd = new AddProperty
            {
                Name = "Stuning Spring",
                ImageUrl = "imagep20.jpg",
                Price = 500000,
                Address = "The Springs, Sydney",
                Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla euismod, nisl eget fermentum aliquam, augue quam aliquet nunc, vitae aliquam nisl nunc eu nisi. Sed vitae nisl eget nunc aliquam aliquet. Sed vitae nisl eget nunc aliquam aliquet.",
                CategoryId = hotelCategory!.CategoryId.ToString()
            };
            var response = await client.PostJsonAsync($"/property", propertyToAdd);
            response.EnsureSuccessStatusCode();
            //after successful post, get the property and check count is 3 for hotel category
            var properties = await client.GetJsonAsync<List<PropertyByCategory>>($"/property/propertyList?categoryId={hotelCategory!.CategoryId}");
            properties!.Count.ShouldBe(3);
        }
    }
}

