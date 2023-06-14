using RealEstateAPP.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace RealEstateAPP.Services
{
    public class RestService : IRestService
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions;
        private IHttpsClientHandlerService _httpsClientHandlerService;

        public RestService(IHttpsClientHandlerService service)
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _httpClient = new HttpClient(handler);
            else
                _httpClient = new HttpClient();
#else
            _httpClient = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<bool> RegisterUser(string name, string email, string password, string phone)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "User/Register"));
            var registerUser = new Register
            {
                Name = name,
                Email = email,
                Password = password,
                Phone = phone
            };
            var json = JsonSerializer.Serialize(registerUser, _serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "User/Login"));
            var loginUser = new Login
            {
                Email = email,
                Password = password
            };
            var json = JsonSerializer.Serialize(loginUser, _serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<Token>(result, _serializerOptions);
            if (tokenResponse == null) return false;

            Preferences.Set(Constants.CurrentToken, tokenResponse.AccessToken);
            Preferences.Set(Constants.CurrentUserId, tokenResponse.UserId);
            Preferences.Set(Constants.CurrentUserName, tokenResponse.UserName);
            return true;
        }

        public async Task<List<Category>> GetCategories()
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "Category/all"));
            SetCurrentAccessTokenForHttpClient();
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<List<Category>>(result, _serializerOptions);
            return categories;
        }

        public async Task<List<TrendingProperty>> GetTrendingProperties()
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "Property/TrendingProperties"));
            SetCurrentAccessTokenForHttpClient();
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            var properties = JsonSerializer.Deserialize<List<TrendingProperty>>(result, _serializerOptions);
            return properties;
        }

        public async Task<List<SearchProperty>> FindProperties(string address)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, $"Property/SearchProperties?address={address}"));
            SetCurrentAccessTokenForHttpClient();
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            var properties = JsonSerializer.Deserialize<List<SearchProperty>>(result, _serializerOptions);
            return properties;
        }

        public async Task<List<PropertyByCategory>> GetPropertyByCategories(string categoryId)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, $"Property/PropertyList?categoryId={categoryId}"));
            SetCurrentAccessTokenForHttpClient();
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            var properties = JsonSerializer.Deserialize<List<PropertyByCategory>>(result, _serializerOptions);
            return properties;
        }

        public async Task<PropertyDetail> GetPropertyDetail(string propertyId)
        {
            //Property/PropertyDetail?id=d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b20
            var uri = new Uri(string.Format(Constants.RestUrl, $"Property/PropertyDetail?propertyId={propertyId}"));
            SetCurrentAccessTokenForHttpClient();
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            var property = JsonSerializer.Deserialize<PropertyDetail>(result, _serializerOptions);
            return property;
        }

        public async Task<List<BookmarkList>> GetBookmarkList()
        {
            var uri = new Uri(string.Format(Constants.RestUrl, $"Bookmark"));
            SetCurrentAccessTokenForHttpClient();
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            var bookmarks = JsonSerializer.Deserialize<List<BookmarkList>>(result, _serializerOptions);
            return bookmarks;
        }

        public async Task<bool> AddBookmark(AddBookmark addBookmark)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, $"Bookmark"));
            SetCurrentAccessTokenForHttpClient();

            var json = JsonSerializer.Serialize(addBookmark, _serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBookmark(string bookmarkId)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, $"Bookmark/{bookmarkId}"));
            SetCurrentAccessTokenForHttpClient();
            var response = await _httpClient.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }

        private void SetCurrentAccessTokenForHttpClient() =>
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get(Constants.CurrentToken, string.Empty));

    }
}

