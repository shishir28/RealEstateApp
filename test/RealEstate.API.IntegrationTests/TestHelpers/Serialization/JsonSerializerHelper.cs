using System.Text.Json;

namespace RealEstate.API.IntegrationTests.TestHelpers.Serialization
{
    public static class JsonSerializerHelper
    {
        public static JsonSerializerOptions DefaultSerializationOptions => new()
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static JsonSerializerOptions DefaultDeserializationOptions => new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
