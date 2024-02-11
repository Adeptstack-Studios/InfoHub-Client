using InfoHub.ContextClasses;
using InfoHub.Utilities;

namespace InfoHub.Pages;

public partial class WeatherPage : ContentPage
{
    int locationIndex = 0;
    public WeatherPage()
    {
        InitializeComponent();
        WeatherLocationRefresh();
    }

    private void refresh_Refreshing(object sender, EventArgs e)
    {
        WeatherLocationRefresh();
    }

    void WeatherLocationRefresh()
    {
        RefreshWeatherData(Utilities.AppResources.settings.WeatherLocations[locationIndex].Latitude, Utilities.AppResources.settings.WeatherLocations[locationIndex].Longitude);
        this.Title = Utilities.AppResources.settings.WeatherLocations[locationIndex].Name;
        refresh.IsRefreshing = false;
        lastRefresh.Text = $"{DateTime.Now.ToShortDateString()}, {DateTime.Now.ToShortTimeString()}";
        return;
    }

    void RefreshWeatherData(string latitude, string longitude)
    {
        WeatherData weather = Web.GetWeatherData(latitude, longitude);
        tempCrt.Text = weather.current.temperature_2m.ToString() + weather.current_units.temperature_2m;
        tempFeel.Text = "Feels like " + weather.current.apparent_temperature.ToString() + weather.current_units.apparent_temperature;
        tempMinMax.Text = weather.daily.temperature_2m_min[0].ToString() + weather.daily_units.temperature_2m_min + " / " + weather.daily.temperature_2m_max[0].ToString() + weather.daily_units.temperature_2m_max;
        humidityCrt.Text = weather.current.relative_humidity_2m.ToString() + weather.current_units.relative_humidity_2m;
        var weatherTitle = Utilities.WeatherUtilities.GetWeatherCodeText(weather.current.weather_code, weather.current.is_day);
        weatherCodeCrt.Text = weatherTitle.text;
        weatherIcon.Source = weatherTitle.imgPath;
        windSpeed.Text = weather.current.wind_speed_10m.ToString() + weather.current_units.wind_speed_10m;
        windDirection.Rotation = weather.current.wind_direction_10m;
        pressureSurfaceCrt.Text = weather.current.surface_pressure.ToString() + weather.current_units.surface_pressure;
        altitude.Text = Utilities.WeatherUtilities.CalculateAltitude(weather.current.pressure_msl, weather.current.surface_pressure);
        UVIndex.Text = Utilities.WeatherUtilities.GetUVIndexString(weather.daily.uv_index_max[0]);
        sunnyHours.Text = Math.Round(weather.daily.sunshine_duration[0] / 60 / 60, 2).ToString() + "h";
    }

    private void navLeft_Clicked(object sender, EventArgs e)
    {
        locationIndex--;
        if (locationIndex < 0)
        {
            locationIndex = Utilities.AppResources.settings.WeatherLocations.Count - 1;
        }
        WeatherLocationRefresh();
    }

    private void navRight_Clicked(object sender, EventArgs e)
    {
        locationIndex++;
        if (locationIndex >= Utilities.AppResources.settings.WeatherLocations.Count)
        {
            locationIndex = 0;
        }
        WeatherLocationRefresh();
    }
}