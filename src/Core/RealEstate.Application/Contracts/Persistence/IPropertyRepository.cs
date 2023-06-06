using RealEstate.Domain.Entities;

namespace RealEstate.Application.Contracts.Persistence
{
    public interface IPropertyRepository : IAsyncRepository<Property>
    {
        Task<List<Property>> GetTrendingProperties();
        Task<List<Property>> GetPropertiesByCategoryId(Guid categoryId);
    }
}
