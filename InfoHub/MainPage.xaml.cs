using InfoHub.ContextClasses;
using InfoHub.Enums;
using InfoHub.Pages;
using InfoHub.Utilities;

namespace InfoHub
{
    public partial class MainPage : ContentPage
    {
        int weatherIndex = 0;
        public MainPage()
        {
            InitializeComponent();
            Data.Create();
            Utilities.AppResources.sensors = Data.LoadSensors();
            Utilities.AppResources.settings = Data.LoadSettings();
            Utilities.AppResources.Timer();

            MainWeatherLocation();

            Thread threadSensorData = new Thread(new ThreadStart(ThreadGetSensorData));
            threadSensorData.Start();
        }

        void MainWeatherLocation()
        {
            for (int i = 0; i < Utilities.AppResources.settings.WeatherLocations.Count; i++)
            {
                if (Utilities.AppResources.settings.WeatherLocations[i].Main == true)
                {
                    RefreshWeatherData(Utilities.AppResources.settings.WeatherLocations[i].Latitude, Utilities.AppResources.settings.WeatherLocations[i].Longitude);
                    this.Title = Utilities.AppResources.settings.WeatherLocations[i].Name;
                    weatherIndex = i;
                    refresh.IsRefreshing = false;
                    return;
                }
            }
            refresh.IsRefreshing = false;
        }

        void RefreshWeatherData(string latitude, string longitude)
        {
            WeatherData weather = Web.GetWeatherData(latitude, longitude);
            tempCrt.Text = weather.current.temperature_2m.ToString() + weather.current_units.temperature_2m;
            tempMinMax.Text = weather.daily.temperature_2m_min[1].ToString() + weather.daily_units.temperature_2m_min + " / " + weather.daily.temperature_2m_max[1].ToString() + weather.daily_units.temperature_2m_max;
            humidityCrt.Text = weather.current.relative_humidity_2m.ToString() + weather.current_units.relative_humidity_2m;
            var weatherTitle = Utilities.WeatherUtilities.GetWeatherCodeText(weather.current.weather_code, weather.current.is_day);
            weatherCodeCrt.Text = weatherTitle.text;
            weatherIcon.Source = weatherTitle.imgPath;
            windSpeedMax.Text = weather.current.wind_speed_10m.ToString() + weather.current_units.wind_speed_10m;
            pressureSurfaceCrt.Text = weather.current.surface_pressure.ToString() + weather.current_units.surface_pressure;
        }

        void ThreadGetSensorData()
        {
            foreach (var item in Utilities.AppResources.sensors)
            {
                if (item.SensorType == SensorType.TemperatureAndPressure)
                {
                    SensorDataTHP sensorData = Web.GetSensorDataTHP(item.IpAddress, item.Port);
                    item.SensorData = sensorData;
                }
            }
        }

        private void NavToSensorsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SensorsPage());
        }

        private void weatherBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WeatherPage(weatherIndex));
        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void Website_Clicked(object sender, EventArgs e)
        {
            Browser.Default.OpenAsync("https://adeptstack.vercel.app").Wait();
        }

        private void GitHub_Clicked(object sender, EventArgs e)
        {
            Browser.Default.OpenAsync("https://github.com/Adeptstack-Studios/InfoHub-Client").Wait();
        }

        private void refresh_Refreshing(object sender, EventArgs e)
        {
            MainWeatherLocation();
        }

        private void NavToLights_Clicked(object sender, EventArgs e)
        {

        }
    }
}