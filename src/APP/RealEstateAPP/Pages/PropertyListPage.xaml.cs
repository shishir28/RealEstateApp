using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class PropertyListPage : ContentPage
{
    private readonly IRestService _restService;
    public PropertyListPage(string categoryId, string categoryName)
    {
        _restService = Resolver.Resolve<IRestService>();
        Title = categoryName;
        GetProperties(categoryId);
        InitializeComponent();
    }

    async void GetProperties(string categoryId)
    {
        var properties = await _restService.GetPropertyByCategories(categoryId);
        cvProperties.ItemsSource = properties;
    }
}

