namespace RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark
{
    public class CreateBookmarkCommandResponse : BaseResponse
    {
        public CreateBookmarkCommandResponse() : base()
        {
        }
        public CreateBookmarkDto Bookmark { get; set; } = default!;
    }
}
