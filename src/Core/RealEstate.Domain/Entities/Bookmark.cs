using RealEstate.Domain.Common;
using System.Text.Json.Serialization;
namespace RealEstate.Domain.Entities
{
    public class Bookmark : AuditableEntity
    {
        public Guid BookmarkId { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }
        public Guid PropertyId { get; set; }

        [JsonIgnore]
        public Property Property { get; set; }
    }
}
