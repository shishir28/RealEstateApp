
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Bookmarks.Commands.DeleteBookmark;

namespace RealEstate.Application.UnitTests.Features.Bookmarks.Commands;

public class DeleteBookmarkCommandHandlerTests
{
    private readonly IBookmarkRepository _bookmarkRepository;
    private readonly IUserRepository _userRepository;

    public DeleteBookmarkCommandHandlerTests()
    {
        _bookmarkRepository = MockBookmarkRepository.GetBookmarkRepository();
        _userRepository = MockUserRepository.GetUserRepository();
    }

    [Fact]
    public async Task DeleteBookmarkTest()
    {
        var bookmarkId = new Guid("b9f9b9b0-5b9a-4b9c-9c9d-8b9b9b9b9b9b");

        var request = new DeleteBookmarkCommand
        {
            BookmarkId = bookmarkId,
            EmailAddress = "john.doe@gmail.com"
        };
        var handler = new DeleteBookmarkCommandHandler(_bookmarkRepository, _userRepository);
        await handler.Handle(request, CancellationToken.None);
    }
}
