
using RealEstate.Application.Contracts.Persistence;
using AutoMapper;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Users.Command.LoginUser;
using RealEstate.Domain.Entities;
namespace RealEstate.Application.UnitTests.Features.Users.LoginUser.Command;

public class LoginUserCommandHandlerTests
{
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandlerTests() =>
        _userRepository = MockUserRepository.GetUserRepository();

    [Fact]
    public async Task LoginUserTest()
    {
        var request = new LoginUserCommand
        {
            Email = "john.doe@gmail.com",
            Password = "Test0101#"
        };
        var handler = new LoginUserCommandHandler(_userRepository);
        var result = await handler.Handle(request, CancellationToken.None);
        result.ShouldBeOfType<User>();
    }
}
