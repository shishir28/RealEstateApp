using MediatR;

namespace RealEstate.Application.Features.Bookmarks.Commands.DeleteBookmark
{
    public class DeleteBookmarkCommand : IRequest
    {
        public Guid BookmarkId { get; set; }
        public string EmailAddress { get; set; }

    }
}
