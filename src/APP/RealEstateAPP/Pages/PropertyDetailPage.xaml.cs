using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class PropertyDetailPage : ContentPage
{
    private string _phoneNumber;
    private readonly IRestService _restService;
    public PropertyDetailPage(string propertyId)
    {
        InitializeComponent();
        _restService = Resolver.Resolve<IRestService>();
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
    }

    void TapMessage_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Sms.ComposeAsync(new SmsMessage
        {
            Recipients = new List<string> { _phoneNumber },
            Body = "Price guide please!"
        });
    }

    void TapCall_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        PhoneDialer.Open(_phoneNumber);
    }

    void ImgBackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}

