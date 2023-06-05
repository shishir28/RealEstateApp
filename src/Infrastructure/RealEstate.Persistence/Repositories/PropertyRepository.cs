using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Persistence.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(RealEstateDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Property>> GetTrendingProperties() =>
            _dbContext.Properties.Where(p => p.IsTrending).ToListAsync();
    }
}
