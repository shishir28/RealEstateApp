using RealEstate.Domain.Entities;

namespace RealEstate.Application.Contracts.Persistence
{
    public interface IBookmarkRepository : IAsyncRepository<Bookmark>
    {
    }
}
