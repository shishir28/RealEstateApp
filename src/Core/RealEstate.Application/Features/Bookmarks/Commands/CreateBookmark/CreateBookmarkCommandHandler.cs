using MediatR;
using RealEstate.Application.Contracts.Persistence;

namespace RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark
{
    public class CreateBookmarkCommandHandler : IRequestHandler<CreateBookmarkCommand, Guid>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IPropertyRepository _propertyRepository;
        public CreateBookmarkCommandHandler(IBookmarkRepository bookmarkRepository, IPropertyRepository propertyRepository)
        {
            _bookmarkRepository = bookmarkRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Guid> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetByIdAsync(request.PropertyId);
            //if(property == null)
            //    throw new ArgumentNullException(nameof(property));

            var result = await _bookmarkRepository.AddAsync(new Domain.Entities.Bookmark
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
