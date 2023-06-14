using Microsoft.Extensions.DependencyInjection;
using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly IRestService _restService;
    public RegisterPage()
    {
        _restService = Resolver.Resolve<IRestService>();
        InitializeComponent();
    }

    async void BtnRegister_Clicked(System.Object sender, System.EventArgs e)
    {
        var result = await _restService.RegisterUser(EntFullName.Text,
            EntEmail.Text,
            EntPassword.Text,
            EntPhone.Text);

        if (result)
        {
            await DisplayAlert("Success", "User registered successfully", "Alright");
            await Navigation.PushModalAsync(new LoginPage());
        }            
        else
        {
            await DisplayAlert("Error", "User registration failed", "Ok");
        }            
    }

    async void TapLogin_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) =>
        await Navigation.PushModalAsync(new LoginPage());
}