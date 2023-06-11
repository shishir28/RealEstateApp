using RealEstateAPP.Pages;
using RealEstateAPP.Services;

namespace RealEstateAPP;

public partial class App : Application
{
    public App(IRestService restService)
    {
        InitializeComponent();

        MainPage = new RegisterPage(restService);
    }
}

