using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Persistence.Repositories
{
    public class BookmarkRepository : BaseRepository<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(RealEstateDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Bookmark>> GetActiveBookmarksByUserIdAsync(Guid userId) =>
             await _dbContext.Bookmarks.Where(b => b.UserId == userId && b.Status).ToListAsync();
    }
}
