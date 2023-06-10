using RealEstate.Domain.Common;
using System.Text.Json.Serialization;

namespace RealEstate.Domain.Entities
{
    public class Property : AuditableEntity
    {
        public Guid PropertyId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool IsTrending { get; set; }
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public ICollection<Bookmark> Bookmarks { get; set; }
    }
}
