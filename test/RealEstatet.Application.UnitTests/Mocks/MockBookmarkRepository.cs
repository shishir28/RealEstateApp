using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Moq;

namespace RealEstate.Application.UnitTests.Mocks;

public class MockBookmarkRepository
{
    public static IBookmarkRepository GetBookmarkRepository()
    {
        var bookmarkId = new System.Guid("b9f9b9b0-5b9a-4b9c-9c9d-8b9b9b9b9b9b");
        var mockBookmarkRepository = new Mock<IBookmarkRepository>();
        mockBookmarkRepository.Setup(repo => repo.AddAsync(It.IsAny<Bookmark>()))
        .ReturnsAsync((Bookmark bookmark) =>
        {
            bookmark.BookmarkId = bookmarkId;
            return bookmark;
        });
        return mockBookmarkRepository.Object;
    }
}
