using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class HomePage : ContentPage
{
    private readonly IRestService _restService;

    public HomePage()
    {
        InitializeComponent();
        _restService = Resolver.Resolve<IRestService>();
        lblUserName.Text = $" Hi {Preferences.Get(Constants.CurrentUserName, string.Empty)}!";
        GetCategories();
        GetTrendingProperties();
    }

    async void GetCategories()
    {
        var categories = await _restService.GetCategories();
        cvCategories.ItemsSource = categories;
    }

    async void GetTrendingProperties()
    {
        var properties = await _restService.GetTrendingProperties();
        cvTopics.ItemsSource = properties;
    }
}

