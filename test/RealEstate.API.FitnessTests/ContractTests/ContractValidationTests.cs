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
            JSchema expectedSchema = JSchema.Parse(matchingSchema);
            //Act

            var response = await _httpClient!.GetJsonAsync<List<object>>("/category");
            var actualResponse = JsonSerializer.Serialize(response, JsonSerializerHelper.DefaultSerializationOptions);
            var result = dataContractValidator.DoContractsMatchForArray(expectedSchema!, actualResponse);

            //Assert
            Assert.True(result);
        }
    }
}
