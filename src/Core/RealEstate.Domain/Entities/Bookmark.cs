using RealEstate.Domain.Common;
using System.Text.Json.Serialization;
namespace RealEstate.Domain.Entities
{
    public class Bookmark: AuditableEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int User_Id { get; set; }
        public int PropertyId { get; set; }
        [JsonIgnore]
        public Property Property { get; set; }
    }
}
