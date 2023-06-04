using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RealEstateDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = _dbContext.Categories;

            return allCategories.ToListAsync();
        }
    }
}
