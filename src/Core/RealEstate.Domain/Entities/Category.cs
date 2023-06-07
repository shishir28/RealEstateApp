using RealEstate.Domain.Common;
namespace RealEstate.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        // [Required(ErrorMessage = "Category name can't be null or empty")]
        public string Name { get; set; }
        // [Required(ErrorMessage = "Image url can't be null or empty")]
        public string ImageUrl { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
