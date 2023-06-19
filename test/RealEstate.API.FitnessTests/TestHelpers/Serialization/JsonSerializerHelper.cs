using System.Text.Json;

namespace RealEstate.API.FitnessTests.TestHelpers.Serialization
{
    internal static class JsonSerializerHelper
    {
        internal static JsonSerializerOptions DefaultSerializationOptions => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        internal static JsonSerializerOptions DefaultDeserializationOptions => new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
