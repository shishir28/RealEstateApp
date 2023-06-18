using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RealEstate.API.FitnessTests.Contracts
{
    public class DataContractTest : IDataContractTest
    {
        public bool DoContractsMatch(HttpResponseMessage expectedResponse, HttpResponseMessage actualResponse)
        {
            var expectedResponseString = JsonConvert.SerializeObject(expectedResponse);
            var actualResponseString = JsonConvert.SerializeObject(actualResponse);
            return DoContractsMatch(expectedResponseString, actualResponseString);
        }

        public bool DoContractsMatch(string expectedResponse, HttpResponseMessage actualResponse)
        {
            var actualResponseString = JsonConvert.SerializeObject(actualResponse);
            return DoContractsMatch(expectedResponse, actualResponseString);
        }

        public bool DoContractsMatch(string expectedResponseString, string actualResponseString)
        {
            var expected = JObject.Parse(expectedResponseString);
            var actual = JObject.Parse(actualResponseString);

            foreach (var property in expected.Properties())
            {
                var property2 = actual.Property(property.Name);
                if (property2 == null) return false;

                if (property.Value.Type != property2.Value.Type) return false;
            }
            return true;
        }
    }
}
