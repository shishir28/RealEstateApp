using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class PropertyListPage : ContentPage
{
    private readonly IRestService _restService;

    public PropertyListPage(string categoryId, string categoryName)
    {        
        InitializeComponent();
        Title = categoryName;
        _restService = Resolver.Resolve<IRestService>();
        GetProperties(categoryId);
    }

    async void GetProperties(string categoryId)
    {
        var properties = await _restService.GetPropertyByCategories(categoryId);
        cvProperties.ItemsSource = properties;
    }

    void cvProperties_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentProperty = e.CurrentSelection.FirstOrDefault() as PropertyByCategory;
        if (currentProperty == null) return;

        Navigation.PushModalAsync(new PropertyDetailPage(currentProperty.PropertyId));
        ((CollectionView)sender).SelectedItem = null;
    }
}

