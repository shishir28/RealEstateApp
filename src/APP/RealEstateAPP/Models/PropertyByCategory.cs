using System.Text.Json.Serialization;

namespace RealEstateAPP.Models
{
    public class PropertyByCategory
    {
        [JsonPropertyName("propertyId")]
        public string PropertyId { get; set; }

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

        [JsonPropertyName("isTrending")]
        public bool IsTrending { get; set; }
    }
}
