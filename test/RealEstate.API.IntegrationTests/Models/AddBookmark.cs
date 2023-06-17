using System.Text.Json.Serialization;

namespace RealEstate.API.IntegrationTests.Models
{
    internal class AddBookmark
    {

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("propertyId")]
        public string PropertyId { get; set; }
    }
}
