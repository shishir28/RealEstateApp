using MediatR;
namespace RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList
{
    public class GetBookmarksListQuery : IRequest<List<BookmarkListVm>>
    {
        public string EmailAddress { get; set; }
    }
}
