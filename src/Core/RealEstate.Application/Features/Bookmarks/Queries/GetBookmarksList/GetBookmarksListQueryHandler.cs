using MediatR;
using RealEstate.Application.Contracts.Persistence;

namespace RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList
{
    public class GetBookmarksListQueryHandler : IRequestHandler<GetBookmarksListQuery, List<BookmarkListVm>>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPropertyRepository _propertyRepository;

        public GetBookmarksListQueryHandler(IBookmarkRepository bookmarkRepository,
        IPropertyRepository propertyRepository,
        IUserRepository userRepository)
        {
            _bookmarkRepository = bookmarkRepository;
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;
        }

        public async Task<List<BookmarkListVm>> Handle(GetBookmarksListQuery request, CancellationToken cancellationToken)
        {
            // following three separate query should use IQueryable and be combined into one query
            // can be done later
            var user = await _userRepository.GetUserByEmail(request.EmailAddress);
            var properties = await _propertyRepository.GetAllAsync();
            var bookmarks = await _bookmarkRepository.GetActiveBookmarksByUserIdAsync(user.UserId);

            var result = from b in bookmarks
                         join p in properties on b.PropertyId equals p.PropertyId
                         select new BookmarkListVm
                         {
                             BookmarkId = b.BookmarkId,
                             UserId = b.UserId,
                             PropertyId = b.PropertyId,
                             Name = p.Name,
                             Price = p.Price,
                             ImageUrl = p.ImageUrl,
                             Address = p.Address,
                             Status = b.Status
                         };
            return result.ToList();
        }
    }
}
