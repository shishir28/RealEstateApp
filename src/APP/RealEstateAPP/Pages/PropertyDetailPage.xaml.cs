using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class PropertyDetailPage : ContentPage
{
    private string _phoneNumber;
    private readonly IRestService _restService;

    private readonly string _propertyId;
    private bool IsBookmarkEnabled;
    private string _bookmarkId;

    public PropertyDetailPage(string propertyId)
    {
        InitializeComponent();
        _restService = Resolver.Resolve<IRestService>();
        this._propertyId = propertyId;
        GetPropertyDetail(propertyId);
    }

    async void GetPropertyDetail(string propertyId)
    {
        var property = await _restService.GetPropertyDetail(propertyId);
        LblPrice.Text = $"${property.Price}";
        LblDescription.Text = property.Detail;
        LblAddress.Text = property.Address;
        ImgProperty.Source = property.FullImageUrl;
        _phoneNumber = property.PhoneNumber;
        _bookmarkId = property.Bookmark?.BookmarkId;

        IsBookmarkEnabled = (property.Bookmark != null);
        if (property.Bookmark == null)
            ImgBookmarkButton.Source = "bookmark_empty_icon";
        else
            ImgBookmarkButton.Source = property.Bookmark.Status ? "bookmark_fill_icon" : "bookmark_empty_icon";
    }

    void TapMessage_Tapped(object sender, TappedEventArgs e) =>
        Sms.ComposeAsync(new SmsMessage
        {
            Recipients = new List<string> { _phoneNumber },
            Body = "Price guide please!"
        });


    void TapCall_Tapped(object sender, TappedEventArgs e) =>
        PhoneDialer.Open(_phoneNumber);

    void ImgBackButton_Clicked(object sender, EventArgs e) =>
        Navigation.PopModalAsync();

    async void ImgBookmarkButton_Clicked(object sender, EventArgs e)
    {
        if (IsBookmarkEnabled)
        {
            var response = await _restService.DeleteBookmark(this._bookmarkId);

            if (response)
            {
                ImgBookmarkButton.Source = "bookmark_empty_icon";
                IsBookmarkEnabled = false;
                this._bookmarkId = string.Empty;
            }
        }
        else
        {
            var resposne = await _restService.AddBookmark(new AddBookmark
            {
                PropertyId = this._propertyId,
                UserId = Preferences.Get(Constants.CurrentUserId, "")
            });

            if (resposne)
            {
                var bookmarks = await _restService.GetBookmarkList();
                this._bookmarkId = bookmarks
                                    .FirstOrDefault(x => x.PropertyId == this._propertyId)
                                    .BookmarkId;

                ImgBookmarkButton.Source = "bookmark_fill_icon";
                IsBookmarkEnabled = true;
            }
        }
    }
}
