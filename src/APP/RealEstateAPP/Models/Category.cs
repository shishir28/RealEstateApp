using System.Text.Json.Serialization;

namespace RealEstateAPP.Models
{
    public class Category
    {
        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        public string FullImageUrl => String.Format(Constants.RestUrl, ImageUrl);
    }
}
