using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class LoginPage : ContentPage
{
    private readonly IRestService _restService;

    public LoginPage(IRestService restService)
    {
        _restService = restService;
        InitializeComponent();
    }

    async void BtnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
        var result = await _restService.LoginUser(EntEmail.Text,
            EntPassword.Text);

        if(result)
        {
            
            Application.Current.MainPage = new CustomTabbedPage(); 
        }
        else
        {
            await DisplayAlert("", "Sign In failed", "Ok");

        }
    }

    async void TapJoinNow_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage(_restService));

    }
}
