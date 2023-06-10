using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Moq;

namespace RealEstate.Application.UnitTests.Mocks;

public class MockBookmarkRepository
{
    public static IBookmarkRepository GetBookmarkRepository()
    {
        var bookmarkId = new Guid("b9f9b9b0-5b9a-4b9c-9c9d-8b9b9b9b9b9b");
        var userId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-8b9b9b9b9b9b");
        var propertyGuid = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f");
        var bookmarks = new List<Bookmark>
        {
            new Bookmark
            {
                BookmarkId = bookmarkId,
                Status = true,
                UserId = userId,
                PropertyId  = propertyGuid
            }
        };
        var mockBookmarkRepository = new Mock<IBookmarkRepository>();
        mockBookmarkRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) =>
            {
                return bookmarks.SingleOrDefault(x => x.BookmarkId == id);
            }
        );
        mockBookmarkRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Bookmark>()));
        mockBookmarkRepository.Setup(repo => repo.AddAsync(It.IsAny<Bookmark>()))
        .ReturnsAsync((Bookmark bookmark) =>
        {
            bookmark.BookmarkId = bookmarkId;
            return bookmark;
        });
        mockBookmarkRepository.Setup(repo => repo.GetActiveBookmarksByUserIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(bookmarks);

        return mockBookmarkRepository.Object;
    }
}
