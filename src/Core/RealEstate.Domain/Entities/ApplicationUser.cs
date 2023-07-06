using Microsoft.AspNet.Identity.EntityFramework;

namespace RealEstate.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
