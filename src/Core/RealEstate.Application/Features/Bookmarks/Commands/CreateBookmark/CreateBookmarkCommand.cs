using MediatR;

namespace RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark
{
    public class CreateBookmarkCommand : IRequest<Guid>
    {
        public Guid BookmarkId { get; set; }
        public Guid UserId { get; set; }
        public Guid PropertyId { get; set; }
    }
}
