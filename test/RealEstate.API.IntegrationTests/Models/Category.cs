using System.Text.Json.Serialization;

namespace RealEstate.API.IntegrationTests.Models
{
    public class Category
    {
        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

    }
}
