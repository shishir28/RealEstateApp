using RealEstateAPP.Pages;
using RealEstateAPP.Services;

namespace RealEstateAPP;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        var accessToken = Preferences.Get(Constants.CurrentToken, string.Empty);

        if(string.IsNullOrEmpty(accessToken))
            MainPage = new RegisterPage();
        else
            MainPage = new CustomTabbedPage();
    }
}

