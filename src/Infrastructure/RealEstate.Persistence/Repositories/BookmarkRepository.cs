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
    }
}
