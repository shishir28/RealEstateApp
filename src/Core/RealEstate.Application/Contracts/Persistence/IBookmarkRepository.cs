using RealEstate.Domain.Entities;

namespace RealEstate.Application.Contracts.Persistence
{
    public interface IBookmarkRepository : IAsyncRepository<Bookmark>
    {
        Task<IList<Bookmark>> GetActiveBookmarksByUserIdAsync(Guid userId);
    }
}
