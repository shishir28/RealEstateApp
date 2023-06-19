using System.Text;
using System.Text.Json;
using RealEstate.API.FitnessTests.TestHelpers.Serialization;

namespace RealEstate.API.FitnessTests.TestHelpers
{
    internal static class WebClientExtensions
    {
        internal static async Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient client, string requestUri, T value)
        {
            var json = JsonSerializer.Serialize(value, JsonSerializerHelper.DefaultSerializationOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(requestUri, content);
        }

        internal static async Task<T> GetJsonAsync<T>(this HttpClient client, string requestUri)
        {
            var response = await client.GetAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(result, JsonSerializerHelper.DefaultDeserializationOptions)!;
        }
    }
}
