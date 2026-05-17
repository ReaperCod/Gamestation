using System;
using Microsoft.Maui.ApplicationModel; // pour MainThread si besoin
using GameStationsClasses;

namespace GameStation
{
    public partial class MainPage : ContentPage
    {
    public MainPage()
    {
        InitializeComponent();

        // initialiser picker depuis la culture actuelle
        languagePicker.SelectedIndex = System.Globalization.CultureInfo.CurrentUICulture.Name.StartsWith("fr") ? 1 : 0;

        // s'abonner pour rafraîchir l'UI quand la langue change
        GameStationsClasses.LocalizedServices.OnLanguageChanged += (culture) =>
            MainThread.BeginInvokeOnMainThread(UpdateTexts);

        UpdateTexts();
    }

    void UpdateTexts()
    {
        TitleLabel.Text = GameStationsClasses.LocalizedServices.GetLocalizedService("Title");
        BoardGamesButton.Text = GameStationsClasses.LocalizedServices.GetLocalizedService("BoardGames");
        OthersButton.Text = GameStationsClasses.LocalizedServices.GetLocalizedService("Others");
    }

    private void OnLanguageChange(object sender, EventArgs e)
    {
        var culture = languagePicker.SelectedIndex == 1 ? "fr-FR" : "en-US";
        GameStationsClasses.LocalizedServices.ChangeLanguage(culture);
        // UpdateTexts() sera appelé via l'abonnement à OnLanguageChanged
    }
    }
}
