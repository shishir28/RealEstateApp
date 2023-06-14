namespace RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList
{
    public class BookmarkListVm
    {
        public Guid BookmarkId { get; set; }

        // property atrributes
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public Guid PropertyId { get; set; }

        public bool Status { get; set; }
        public Guid UserId { get; set; }
    }
}