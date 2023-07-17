using RealEstate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//using EntityState = System.Data.Entity.EntityState;

namespace RealEstate.Persistence;
public class RealEstateDbContext :IdentityDbContext<ApplicationUser>
{
    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) 
        : base(options)
    {
       
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
