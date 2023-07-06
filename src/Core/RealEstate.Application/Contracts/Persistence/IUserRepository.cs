using RealEstate.Domain.Entities;

namespace RealEstate.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<ApplicationUser>
    {
        Task<bool> DoesUserNameExist(string email);
        Task<ApplicationUser> GetUserByEmail(string email);
    }
}
