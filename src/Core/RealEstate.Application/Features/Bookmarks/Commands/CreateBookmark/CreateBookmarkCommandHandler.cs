using MediatR;
using RealEstate.Application.Contracts.Persistence;

namespace RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark
{
    public class CreateBookmarkCommandHandler : IRequestHandler<CreateBookmarkCommand, CreateBookmarkCommandResponse>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IPropertyRepository _propertyRepository;
        public CreateBookmarkCommandHandler(IBookmarkRepository bookmarkRepository, IPropertyRepository propertyRepository)
        {
            _bookmarkRepository = bookmarkRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<CreateBookmarkCommandResponse> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateBookmarkCommandResponse();
            var property = await _propertyRepository.GetByIdAsync(request.PropertyId);

            if (property == null)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>
                {
                    "Property Not Found"
                };
            }

            if (response.Success)
            {
                var result = await _bookmarkRepository.AddAsync(new Domain.Entities.Bookmark
                {
                    BookmarkId = Guid.NewGuid(),
                    UserId = request.UserId,
                    PropertyId = request.PropertyId,
                    Status = true
                });
                response.Success = true;
                response.Bookmark = new CreateBookmarkDto
                {
                    BookmarkId = result.BookmarkId
                };
            }
            return response;
        }
    }
}
