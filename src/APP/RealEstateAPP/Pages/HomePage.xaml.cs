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
        cvTopPicks.ItemsSource = properties;
    }

    void cvCategories_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentCategory = e.CurrentSelection.FirstOrDefault() as Category;
        if (currentCategory == null) return;

        Navigation.PushAsync(new PropertyListPage(currentCategory.CategoryId, currentCategory.Name));

        ((CollectionView)sender).SelectedItem = null;
    }

    void cvTopPicks_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentProperty = e.CurrentSelection.FirstOrDefault() as TrendingProperty;
        if (currentProperty == null) return;

        Navigation.PushModalAsync(new PropertyDetailPage(currentProperty.PropertyId));
        ((CollectionView)sender).SelectedItem = null;
    }

    void TapSearch_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) =>
        Navigation.PushModalAsync(new SearchPage());
}
