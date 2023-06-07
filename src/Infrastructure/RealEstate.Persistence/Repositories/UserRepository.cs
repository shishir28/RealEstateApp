using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RealEstateDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> DoesUserNameExist(string email) =>
             await _dbContext.Users.AnyAsync(u => u.Email == email);
    }
}
