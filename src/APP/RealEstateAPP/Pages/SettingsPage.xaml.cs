﻿namespace RealEstateAPP.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    void TapLogout_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Preferences.Set(Constants.CurrentToken, string.Empty);
        Application.Current.MainPage = new LoginPage();
    }
}