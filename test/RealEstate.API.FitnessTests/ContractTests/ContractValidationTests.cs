using System.Text.Json;
using Newtonsoft.Json.Schema;
using RealEstate.API.FitnessTests.Fixtures;
using RealEstate.API.FitnessTests.TestHelpers;
using RealEstate.API.FitnessTests.TestHelpers.Serialization;

namespace RealEstate.API.FitnessTests.ContractTests
{
    public class ContractValidationTests : BaseRestFixture
    {

        private HttpClient _httpClient;
        public ContractValidationTests(FitnessWebApplicationFactory<Program> factory) : base(factory) =>
            _httpClient = CreateWebClientForAuthenticatedUser();

        [Fact]
        public async Task Category_Get_Calls_Have_Matching_Contracts()
        {
            //Arrange

            var dataContractValidator = Resolver.Resolve<IDataContractValidator>();
            var matchingSchema = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContractTests/ExpectedResponse/Categories-Schema.json"));
            var expectedSchema = JSchema.Parse(matchingSchema);
            //Act

            var response = await _httpClient!.GetJsonAsync<List<object>>("/category");
            var actualResponse = JsonSerializer.Serialize(response, JsonSerializerHelper.DefaultSerializationOptions);
            var result = dataContractValidator.DoContractsMatchForArray(expectedSchema!, actualResponse);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Property_Get_List_For_Trendies_Calls_Have_Matching_Contracts()
        {
            //Arrange
            var dataContractValidator = Resolver.Resolve<IDataContractValidator>();
            var matchingSchema = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContractTests/ExpectedResponse/Properties-Schema.json"));
            var expectedSchema = JSchema.Parse(matchingSchema);

            //Act
            var response = await _httpClient.GetJsonAsync<List<object>>($"/property/trendingproperties");
            var actualResponse = JsonSerializer.Serialize(response, JsonSerializerHelper.DefaultSerializationOptions);
            var result = dataContractValidator.DoContractsMatchForArray(expectedSchema!, actualResponse);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Property_Get_List_By_Categories_Calls_Have_Matching_Contracts()
        {
            //Arrange        
            var dataContractValidator = Resolver.Resolve<IDataContractValidator>();
            var matchingSchema = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContractTests/ExpectedResponse/Properties-Schema.json"));
            var expectedSchema = JSchema.Parse(matchingSchema);

            var penthouseCategory = GenesisDataState.GetCategories().FirstOrDefault(x => x.Name == "Penthouse");

            //Act
            var response = await _httpClient!.GetJsonAsync<List<object>>($"/property/propertyList?categoryId={penthouseCategory!.CategoryId}");
            var actualResponse = JsonSerializer.Serialize(response, JsonSerializerHelper.DefaultSerializationOptions);
            var result = dataContractValidator.DoContractsMatchForArray(expectedSchema!, actualResponse);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Property_Get_List_For_Search_Calls_Have_Matching_Contracts()
        {
            //Arrange
            var dataContractValidator = Resolver.Resolve<IDataContractValidator>();
            var matchingSchema = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContractTests/ExpectedResponse/Properties-Schema.json"));
            var expectedSchema = JSchema.Parse(matchingSchema);

            var address = "Trevi Close";

            //Act
            var response = await _httpClient.GetJsonAsync<List<object>>($"/property/searchProperties?address={address}");
            var actualResponse = JsonSerializer.Serialize(response, JsonSerializerHelper.DefaultSerializationOptions);
            var result = dataContractValidator.DoContractsMatchForArray(expectedSchema!, actualResponse);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Property_Get_Detail_By_Id_Calls_Have_Matching_Contracts()
        {
            //Arrange
          
            var dataContractValidator = Resolver.Resolve<IDataContractValidator>();
            var expectedProperty = GenesisDataState.GetProperties().FirstOrDefault(x => x.Name == "Stuning Drift Street");
            var matchingSchema = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContractTests/ExpectedResponse/PropertyDetail-Schema.json"));
            var expectedSchema = JSchema.Parse(matchingSchema);

            //Act
            var response = await _httpClient.GetJsonAsync<object>($"/property/{expectedProperty!.PropertyId}");
            var actualResponse = JsonSerializer.Serialize(response, JsonSerializerHelper.DefaultSerializationOptions);
            var result = dataContractValidator.DoContractsMatch(expectedSchema!, actualResponse);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Bookmark_Get_ListCalls_Have_Matching_Contracts()
        {
            //Arrange
            //JSchemaGenerator generator = new JSchemaGenerator();
            //JSchema schema1 = generator.Generate(typeof(List<BookmarkListVm>));
            var dataContractValidator = Resolver.Resolve<IDataContractValidator>();
            var matchingSchema = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContractTests/ExpectedResponse/Bookmarks-Schema.json"));
            var expectedSchema = JSchema.Parse(matchingSchema);

            //Act
            var response = await _httpClient.GetJsonAsync<List<object>>($"/bookmark");
            var actualResponse = JsonSerializer.Serialize(response, JsonSerializerHelper.DefaultSerializationOptions);
            var result = dataContractValidator.DoContractsMatchForArray(expectedSchema!, actualResponse);

            //Assert
            Assert.True(result);
        }
    }
}
