namespace InfoHub;

public partial class WeatherSettings : ContentPage
{
    public WeatherSettings()
    {
        InitializeComponent();
        ShowLocations();
    }

    private void SaveBtn_Clicked(object sender, EventArgs e)
    {
        int id = 0;
        if (Utilities.settings.WeatherSettings.Count > 0)
        {
            id = Utilities.settings.WeatherSettings[Utilities.settings.WeatherSettings.Count - 1].ID + 1;
        }

        Utilities.settings.WeatherSettings.Add(new WeatherLocations
        {
            ID = id,
            Name = location.Text,
            Longitude = longitude.Text,
            Latitude = latitude.Text,
            Main = isMain.IsChecked
        });
        Data.SaveSettings(Utilities.settings);
        ShowLocations();
    }

    void ShowLocations()
    {
        foreach (var item in Utilities.settings.WeatherSettings)
        {
            WeatherLocationsView view = new WeatherLocationsView
            {
                Name = item.Name,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
            };

            weatherLocationData.Children.Add(view);
        }
    }
}