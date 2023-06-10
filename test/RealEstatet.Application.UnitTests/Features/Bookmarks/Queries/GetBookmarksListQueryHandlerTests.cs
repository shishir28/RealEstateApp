
using RealEstate.Application.Contracts.Persistence;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList;

namespace RealEstate.Application.UnitTests.Features.Bookmarks.Queries;

public class GetBookmarksListQueryHandlerTests
{
    private readonly IUserRepository _userRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IBookmarkRepository _bookmarkRepository;

    public GetBookmarksListQueryHandlerTests()
    {
        _userRepository = MockUserRepository.GetUserRepository();
        _propertyRepository = MockPropertyRepository.GetPropertyRepository();
        _bookmarkRepository = MockBookmarkRepository.GetBookmarkRepository();
    }


    [Fact]
    public async Task GetBookmarksListTest()
    {
        var bookmarkId = new System.Guid("b9f9b9b0-5b9a-4b9c-9c9d-8b9b9b9b9b9b");
        var userId = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-8b9b9b9b9b9b");
        var houseGuid = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f");

        var request = new GetBookmarksListQuery
        {
            EmailAddress = "john.doe@email.com"
        };
        var handler = new GetBookmarksListQueryHandler(_bookmarkRepository, _propertyRepository, _userRepository);
        var result = await handler.Handle(request, CancellationToken.None);
        result.Count.ShouldBe(1);
        result.First().BookmarkId.ShouldBe(bookmarkId);
        result.First().UserId.ShouldBe(userId);
        result.First().PropertyId.ShouldBe(houseGuid);

    }
}
