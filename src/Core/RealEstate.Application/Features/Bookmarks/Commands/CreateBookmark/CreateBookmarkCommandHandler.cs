using MediatR;
using RealEstate.Application.Contracts.Persistence;

namespace RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark
{
    public class CreateBookmarkCommandHandler : IRequestHandler<CreateBookmarkCommand, Guid>
    {
        private readonly IBookmarkRepository _bookRepository;
        public CreateBookmarkCommandHandler(IBookmarkRepository bookRepository) =>
            _bookRepository = bookRepository;

        public async Task<Guid> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.AddAsync(new Domain.Entities.Bookmark
            {
                BookmarkId = Guid.NewGuid(),
                UserId = request.UserId,
                PropertyId = request.PropertyId,
                Status = true
            });
            return result.BookmarkId;
        }
    }
}
