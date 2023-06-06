using RealEstate.Domain.Entities;

namespace RealEstate.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
