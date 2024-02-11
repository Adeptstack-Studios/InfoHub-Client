namespace InfoHub.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void WeatherSettings_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GeneralWeatherSettingsPage());
    }

    private void WeatherLocations_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WeatherSettings());
    }

    private void LegalSettings_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LegalPage());
    }

    private void CreditsBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreditsPage());
    }
}