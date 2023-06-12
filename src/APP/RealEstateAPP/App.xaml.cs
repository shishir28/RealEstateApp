using RealEstateAPP.Pages;
using RealEstateAPP.Services;

namespace RealEstateAPP;

public partial class App : Application
{
    public App(IRestService restService)
    {
        InitializeComponent();
        var accessToken = Preferences.Get(Constants.CurrentToken, string.Empty);
        if(string.IsNullOrEmpty(accessToken))
            MainPage = new RegisterPage(restService);
        else
            MainPage = new CustomTabbedPage();

    }
}

