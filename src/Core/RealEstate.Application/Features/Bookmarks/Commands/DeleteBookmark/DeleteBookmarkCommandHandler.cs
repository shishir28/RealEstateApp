using MediatR;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Application.Exceptions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Bookmarks.Commands.DeleteBookmark
{
    public class DeleteBookmarkCommandHandler : IRequestHandler<DeleteBookmarkCommand>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUserRepository _userRepository;

        public DeleteBookmarkCommandHandler(IBookmarkRepository bookmarkRepository, IUserRepository userRepository)
        {
            _bookmarkRepository = bookmarkRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteBookmarkCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.EmailAddress) ?? throw new NotFoundException(nameof(User), request.EmailAddress);
            var bookmarkToDelete = await _bookmarkRepository.GetByIdAsync(request.BookmarkId) ?? throw new NotFoundException(nameof(Bookmark), request.BookmarkId);

            if (bookmarkToDelete.UserId != user.UserId)
                throw new BadRequestException("You do not own this bookmark.");
            await _bookmarkRepository.DeleteAsync(bookmarkToDelete);
        }
    }
}
