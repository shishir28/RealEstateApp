using System.Text;
using System.Text.Json;
using RealEstate.API.IntegrationTests.Models;
using RealEstate.API.IntegrationTests.TestHelpers.Serialization;
using Shouldly;

namespace RealEstate.API.IntegrationTests.Controllers;
public class BookmarkControllerTests : BaseControllerTests
{
    public BookmarkControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {

    }

    [Fact]
    public async Task GetAll_ReturnsExpectedArrayOfBookmarks()
    {
        var client = await CreateWebClientForAuthenticatedUser();
        var response = await client.GetAsync("/bookmark");
        var result = await response.Content.ReadAsStringAsync();
        var bookmarks = JsonSerializer.Deserialize<List<BookmarkList>>(result, JsonSerializerHelper.DefaultDeserializationOptions);
        response.EnsureSuccessStatusCode();
        bookmarks!.Count.ShouldBe(1);
    }

    [Fact]
    public async Task Post_WithValidBookmark_ReturnsCreatedResult()
    {
        var client = await CreateWebClientForAuthenticatedUser();
        var defaultUser = GenesisDataState.GetUsers().FirstOrDefault(x => x.Email == "andrew@email.com");
        var currentProperty = GenesisDataState.GetProperties().FirstOrDefault(x => x.Name == "Stuning Marina");

        var bookmarkToAdd = new AddBookmark
        {
            PropertyId = currentProperty!.PropertyId.ToString(),
            UserId = defaultUser!.UserId.ToString()
        };

        var json = JsonSerializer.Serialize(bookmarkToAdd, JsonSerializerHelper.DefaultSerializationOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/bookmark", content);
        response.EnsureSuccessStatusCode();
        // hit The API and now we should have two bookmarks
        response = await client.GetAsync("/bookmark");
        var result = await response.Content.ReadAsStringAsync();
        var bookmarks = JsonSerializer.Deserialize<List<BookmarkList>>(result, JsonSerializerHelper.DefaultDeserializationOptions);
        bookmarks!.Count.ShouldBe(2);
    }

    //[Fact]
    //public async Task Post_WithInvalidBookmark_ReturnsBadRequest()
    //{
    //    var client = await CreateWebClientForAuthenticatedUser();
    //    var bookmarkToAdd = new AddBookmark
    //    {
    //        PropertyId = "00000000-0000-0000-0000-000000000000",
    //        UserId = "00000000-0000-0000-0000-000000000000"
    //    };

    //    var json = JsonSerializer.Serialize(bookmarkToAdd, JsonSerializerHelper.DefaultSerializationOptions);
    //    var content = new StringContent(json, Encoding.UTF8, "application/json");
    //    var response = await client.PostAsync("/bookmark", content);
    //    response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    //}

    [Fact]
    public async Task Delete_WithValidBookmark_ReturnsNoContent()
    {
        var client = await CreateWebClientForAuthenticatedUser();
        var bookmarkToDelete = GenesisDataState.GetBookmarks().FirstOrDefault(x => x.BookmarkId == new Guid("a46ab603-903e-4460-9ba7-da5f3f0f9e92"));
        var response = await client.DeleteAsync($"/bookmark/{bookmarkToDelete!.BookmarkId}");
        response.EnsureSuccessStatusCode();
        // hit The API and now we should have no bookmarks
        response = await client.GetAsync("/bookmark");
        var result = await response.Content.ReadAsStringAsync();
        var bookmarks = JsonSerializer.Deserialize<List<BookmarkList>>(result, JsonSerializerHelper.DefaultDeserializationOptions);
        bookmarks!.Count.ShouldBe(0);
    }

}
