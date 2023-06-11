using System;
using System.Text.Json.Serialization;

namespace RealEstateAPP.Models
{
    public class PropertyDetail
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

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("bookmark")]
        public Bookmark Bookmark { get; set; }
    }

    public class Bookmark
    {
        [JsonPropertyName("bookmarkId")]
        public string BookmarkId { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("propertyId")]
        public string PropertyId { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("createdBy")]
        public object CreatedBy { get; set; }

        [JsonPropertyName("lastModified")]
        public object LastModified { get; set; }

        [JsonPropertyName("lastModifiedBy")]
        public object LastModifiedBy { get; set; }
    }
}
