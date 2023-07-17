
using RealEstate.Application.Contracts.Persistence;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Users.Commands.RegisterUser;

namespace RealEstate.Application.UnitTests.Features.Users.Commands;

public class RegisterUserCommandHandlerTests
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandlerTests() =>
        _userRepository = MockUserRepository.GetUserRepository();

    [Fact]
    public async Task RegisterUserTest()
    {
        var request = new RegisterUserCommand
        {
            Email = "john.doe@gmail.com",
            Password = "Test0101#"
        };
        var handler = new RegisterUserCommandHandler(_userRepository);
        var result = await handler.Handle(request, CancellationToken.None);
        result.ShouldBeOfType<Guid>();
    }
}
