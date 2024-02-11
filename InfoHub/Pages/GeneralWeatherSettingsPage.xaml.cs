using InfoHub.Enums;
using InfoHub.Utilities;

namespace InfoHub.Pages;

public partial class GeneralWeatherSettingsPage : ContentPage
{
    public GeneralWeatherSettingsPage()
    {
        InitializeComponent();
        pickerTemperatureUnit.SelectedIndex = (int)Utilities.AppResources.settings.WeatherSettings.TemperatureUnit;
        pickerSpeedUnit.SelectedIndex = (int)Utilities.AppResources.settings.WeatherSettings.SpeedUnit;
    }

    private void pickerTemperatureUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utilities.AppResources.settings.WeatherSettings.TemperatureUnit = (TemperatureUnit)pickerTemperatureUnit.SelectedIndex;
        Data.SaveSettings(Utilities.AppResources.settings);
    }

    private void pickerSpeedUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utilities.AppResources.settings.WeatherSettings.SpeedUnit = (SpeedUnit)pickerSpeedUnit.SelectedIndex;
        Data.SaveSettings(Utilities.AppResources.settings);
    }
}