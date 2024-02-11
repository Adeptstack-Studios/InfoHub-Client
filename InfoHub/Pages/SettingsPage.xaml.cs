namespace InfoHub.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void WeatherSettings_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WeatherSettings());
    }
}