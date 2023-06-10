using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Moq;

namespace RealEstate.Application.UnitTests.Mocks;

public class MockUserRepository
{
    public static IUserRepository GetUserRepository()
    {
        var userId = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-8b9b9b9b9b9b");
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(repo => repo.DoesUserNameExist(It.IsAny<string>())).ReturnsAsync(false);
        mockUserRepository.Setup(repo => repo.AddAsync(It.IsAny<User>()))
        .ReturnsAsync((User user) =>
        {
            user.UserId = userId;
            return user;
        });

        mockUserRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>()))
        .ReturnsAsync((string email) =>
        {
            return new User
            {
                UserId = userId,
                Email = email,
                Password = "Test0101#",
                Name = "John Doe"
            }; 
        });
        return mockUserRepository.Object;
    }
}
