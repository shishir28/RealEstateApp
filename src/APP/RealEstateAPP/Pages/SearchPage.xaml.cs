using RealEstateAPP.Models;
using RealEstateAPP.Services;

namespace RealEstateAPP.Pages;

public partial class SearchPage : ContentPage
{
    private readonly IRestService _restService;
    public SearchPage()
    {
        InitializeComponent();
        _restService = Resolver.Resolve<IRestService>();
    }

    void ImgBackBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    async void SbProperty_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.NewTextValue)) return;

        var properties = await _restService.FindProperties(e.NewTextValue);
         CvSearch.ItemsSource = properties; 
    }

    async void CvSearch_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentProperty = e.CurrentSelection.FirstOrDefault() as SearchProperty;
        if (currentProperty == null) return;

        await Navigation.PushModalAsync(new PropertyDetailPage(currentProperty.PropertyId));
        ((CollectionView)sender).SelectedItem = null;
    }
}

