
using RealEstate.Application.Contracts.Persistence;
using AutoMapper;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Users.Command.RegisterUser;

namespace RealEstate.Application.UnitTests.Features.Users.RegisterUser.Command;

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
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            Password = "Test0101#",
            ConfirmPassword = "Test0101#"
        };
        var handler = new RegisterUserCommandHandler(_userRepository);
        var result = await handler.Handle(request, CancellationToken.None);
        result.ShouldBeOfType<Guid>();
    }
}
