

using Microsoft.AspNetCore.Identity;

namespace RealEstate.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {   
        public ICollection<Property> Properties { get; set; }
    }
}
