using System.Text.Json.Serialization;

namespace RealEstateAPP.Models
{
    public class AddBookmark
    {

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("propertyId")]
        public string PropertyId { get; set; }
    }
}
