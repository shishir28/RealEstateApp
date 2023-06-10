using MediatR;

namespace RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark
{
    public class CreateBookmarkCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid PropertyId { get; set; }
    }
}
