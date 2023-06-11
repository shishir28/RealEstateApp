using RealEstateAPP.Models;

namespace RealEstateAPP.Services
{
    public interface IRestService
    {
        Task<bool> RegisterUser(string name, string email, string password, string phone);
        Task<bool> LoginUser(string email, string password);
        Task<List<Category>> GetCategories();
        Task<List<TrendingProperty>> GetTrendingProperties();
        Task<List<SearchProperty>> FindProperties(string address);
        Task<List<PropertyByCategory>> GetPropertyByCategories(string categoryId);
        Task<PropertyDetail> GetPropertyDetail(string propertyId);
        Task<List<Bookmark>> GetBookmarkList();
        Task<bool> AddBookmark(AddBookmark addBookmark);
        Task<bool> DeleteBookmark(string bookmarkId);
    }
}
