using RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList;

namespace RealEstate.Application.Features.Properties.Queries
{
    public class PropertyListVm
    {
        public Guid PropertyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool IsTrending { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public ICollection<BookmarkListVm> Bookmarks { get; set; }
    }
}
