using System.Text.Json.Serialization;

namespace RealEstateAPP.Models
{
    public class BookmarkList
    {

        [JsonPropertyName("bookmarkId")]
        public string BookmarkId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("propertyId")]
        public string PropertyId { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        public string FullImageUrl => String.Format(Constants.RestUrl, ImageUrl);
    }
}
