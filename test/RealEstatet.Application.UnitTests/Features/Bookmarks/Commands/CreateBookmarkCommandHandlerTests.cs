
using RealEstate.Application.Contracts.Persistence;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark;
namespace RealEstate.Application.UnitTests.Features.Bookmarks.Commands;

public class CreateBookmarkCommandHandlerTests
{
    private readonly IBookmarkRepository _bookmarkRepository;

    public CreateBookmarkCommandHandlerTests() =>
        _bookmarkRepository = MockBookmarkRepository.GetBookmarkRepository();

    [Fact]
    public async Task CreateBookmarkTest()
    {
        var propertyId = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f");
        var userId = Guid.Parse("8399c62e-d0b4-49bc-a8c6-0a7a0446c459");

        var request = new CreateBookmarkCommand
        {
            UserId = userId,
            PropertyId = propertyId
        };
        var handler = new CreateBookmarkCommandHandler(_bookmarkRepository);
        var result = await handler.Handle(request, CancellationToken.None);
        result.ShouldBeOfType<Guid>();
    }
}
