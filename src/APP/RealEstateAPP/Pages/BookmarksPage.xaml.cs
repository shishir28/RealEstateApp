using RealEstateAPP.Models;
using RealEstateAPP.Services;


namespace RealEstateAPP.Pages;

public partial class BookmarksPage : ContentPage
{
  
    private readonly IRestService _restService;

    private readonly string _propertyId;
    private bool IsBookmarkEnabled;
    private string _bookmarkId;


    public BookmarksPage()
    {
        InitializeComponent();
        _restService = Resolver.Resolve<IRestService>();     
        GetPropertiesList();
    }

    async  void GetPropertiesList()
    {
        // GetBookmarkList returns list of propeerties which are bookmarked
        var properties = await _restService.GetBookmarkList();
        cvProperties.ItemsSource = properties;
    }

    void cvProperties_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentProperty = e.CurrentSelection.FirstOrDefault() as BookmarkList;
        if (currentProperty == null) return;

        Navigation.PushModalAsync(new PropertyDetailPage(currentProperty.PropertyId));
        ((CollectionView)sender).SelectedItem = null;
    }
}

