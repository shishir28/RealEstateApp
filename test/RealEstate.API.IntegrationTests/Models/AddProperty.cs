
using System.Text.Json.Serialization;

namespace RealEstate.API.IntegrationTests.Models
{
    internal class AddProperty
    {

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("CategoryId")]
        public string CategoryId { get; set; }
    }
}
