using InfoHub.ContentViews;
using InfoHub.ContextClasses;
using InfoHub.Utilities;

namespace InfoHub.Pages;

public partial class WeatherPage : ContentPage
{
    int locationIndex = 0;
    public WeatherPage(int mainWeather)
    {
        InitializeComponent();
        locationIndex = mainWeather;
        WeatherLocationRefresh();
    }

    private void refresh_Refreshing(object sender, EventArgs e)
    {
        WeatherLocationRefresh();
    }

    void WeatherLocationRefresh()
    {
        Thread weatherThread = new Thread(delegate ()
        {
            Dispatcher.Dispatch(() =>
            {
                loading.IsVisible = true;
                busy.IsRunning = true;
            });
            bool isConnected = Web.IsConnectedToInternet();

            if (AppResources.settings.WeatherLocations.Count > 0 && isConnected)
            {
                RefreshWeatherData(Utilities.AppResources.settings.WeatherLocations[locationIndex].Latitude, Utilities.AppResources.settings.WeatherLocations[locationIndex].Longitude);
                Dispatcher.Dispatch(() =>
                {
                    this.Title = AppResources.settings.WeatherLocations[locationIndex].Name;
                    refresh.IsEnabled = false;
                });
            }
            else if (AppResources.settings.WeatherLocations.Count <= 0)
            {
                Dispatcher.Dispatch(() =>
                {
                    this.Title = "No locations!";
                    refresh.IsEnabled = false;
                });
            }
            else
            {
                Dispatcher.Dispatch(() => this.Title = "No internet!");
            }
        });
        weatherThread.Start();
        lastRefresh.Text = $"{DateTime.Now.ToShortDateString()}, {DateTime.Now.ToShortTimeString()}";
        return;
    }

    void RefreshWeatherData(string latitude, string longitude)
    {
        WeatherData weather = Web.GetWeatherData(latitude, longitude);
        Dispatcher.Dispatch(() =>
        {
            tempCrt.Text = weather.current.temperature_2m.ToString() + weather.current_units.temperature_2m;
            tempFeel.Text = "Feels like " + weather.current.apparent_temperature.ToString() + weather.current_units.apparent_temperature;
            tempMinMax.Text = weather.daily.temperature_2m_min[1].ToString() + weather.daily_units.temperature_2m_min + " / " + weather.daily.temperature_2m_max[1].ToString() + weather.daily_units.temperature_2m_max;
            humidityCrt.Text = weather.current.relative_humidity_2m.ToString() + weather.current_units.relative_humidity_2m;
            var weatherTitle = WeatherUtilities.GetWeatherCodeText(weather.current.weather_code, weather.current.is_day);
            weatherCodeCrt.Text = weatherTitle.text;
            weatherIcon.Source = weatherTitle.imgPath;
            windSpeed.Text = weather.current.wind_speed_10m.ToString() + weather.current_units.wind_speed_10m;
            windDirection.Rotation = weather.current.wind_direction_10m;
            pressureSurfaceCrt.Text = weather.current.surface_pressure.ToString() + weather.current_units.surface_pressure;
            altitude.Text = WeatherUtilities.CalculateAltitude(weather.current.pressure_msl, weather.current.surface_pressure);
            UVIndex.Text = WeatherUtilities.GetUVIndexString(weather.daily.uv_index_max[1]);
            sunnyHours.Text = Math.Round(weather.daily.sunshine_duration[1] / 60 / 60, 2).ToString() + "h";
        });

        DateTime sunr = DateTime.Parse(weather.daily.sunrise[1]);
        DateTime suns = DateTime.Parse(weather.daily.sunset[1]);
        Dispatcher.Dispatch(() => sunrise.Text = sunr.ToShortTimeString());
        Dispatcher.Dispatch(() => sunset.Text = suns.ToShortTimeString());

        Thread sunProgressThread = new Thread(delegate ()
        {
            Thread.Sleep(2000);
            ShowStatus(weather);
            SunProgress(sunr, suns);
        });
        Thread dailyThread = new Thread(delegate ()
        {
            Thread.Sleep(2000);
            GenerateDailyWeatherCrads(weather);
            GenerateHourlyWeatherCards(weather, sunr, suns);
        });
        sunProgressThread.Start();
        dailyThread.Start();

        Dispatcher.Dispatch(() => refresh.IsRefreshing = false);
    }

    void SunProgress(DateTime sunr, DateTime suns)
    {
        TimeSpan gesSun = suns - sunr;
        TimeSpan crtSun = DateTime.Now - sunr;
        double maxWidth = gesSunProgress.Width;

        double percent = crtSun.TotalSeconds / gesSun.TotalSeconds;
        double progressWidth = maxWidth * percent;
        if (progressWidth > maxWidth)
        {
            progressWidth = maxWidth + 30;
        }
        else if (progressWidth < -50)
        {
            progressWidth = -25;
        }
        Dispatcher.Dispatch(() => sun.Margin = new Thickness(-25 + progressWidth, 0, 0, 0));
        Dispatcher.Dispatch(() => sunProgress.WidthRequest = progressWidth);
    }

    void GenerateHourlyWeatherCards(WeatherData weather, DateTime sunr, DateTime suns)
    {
        //hourlyForecast
        Dispatcher.Dispatch(() => forecastHourly.Children.Clear());
        int currentHour = DateTime.Now.Hour + 24;
        for (int i = currentHour; i < currentHour + 25; i++)
        {
            DateTime time = DateTime.Parse(weather.hourly.time[i]);
            int isDay = 1;
            if (time.Hour > suns.Hour || time.Hour < sunr.Hour)
                isDay = 0;
            HourlyForecastView hourlyForecast = new HourlyForecastView()
            {
                Time = time.ToShortTimeString(),
                WeatherCodeIcon = WeatherUtilities.GetWeatherCodeText(weather.hourly.weather_code[i], isDay).imgPath,
                Temperature = weather.hourly.temperature_2m[i] + weather.hourly_units.temperature_2m,
                Humidity = weather.hourly.relative_humidity_2m[i] + weather.hourly_units.relative_humidity_2m,
            };
            Dispatcher.Dispatch(() => forecastHourly.Children.Add(hourlyForecast));
        }

        Dispatcher.Dispatch(() =>
        {
            refresh.IsEnabled = true;
            loading.IsVisible = false;
            busy.IsRunning = false;
        });
    }

    void ShowStatus(WeatherData weather)
    {
        int currentHour = DateTime.Now.Hour + 24;

        for (int i = currentHour; i < currentHour + 8; i++)
        {
            DateTime time = DateTime.Parse(weather.hourly.time[i]);
            if (time.Hour == 2)
            {
                Dispatcher.Dispatch(() => futureStatus.Text = $"{WeatherUtilities.GetWeatherCodeText(weather.hourly.weather_code[i], 0).text} at night at {weather.hourly.temperature_2m[i] + weather.hourly_units.temperature_2m}");
                break;
            }
            else if (time.Hour == 8)
            {
                Dispatcher.Dispatch(() => futureStatus.Text = $"{WeatherUtilities.GetWeatherCodeText(weather.hourly.weather_code[i], 1).text} in the morning at {weather.hourly.temperature_2m[i] + weather.hourly_units.temperature_2m}");
                break;
            }
            else if (time.Hour == 12)
            {
                Dispatcher.Dispatch(() => futureStatus.Text = $"{WeatherUtilities.GetWeatherCodeText(weather.hourly.weather_code[i], 1).text} at noon at {weather.hourly.temperature_2m[i] + weather.hourly_units.temperature_2m}");
                break;
            }
            else if (time.Hour == 16)
            {
                Dispatcher.Dispatch(() => futureStatus.Text = $"{WeatherUtilities.GetWeatherCodeText(weather.hourly.weather_code[i], 1).text} in the afternoon at {weather.hourly.temperature_2m[i] + weather.hourly_units.temperature_2m}");
                break;
            }
            else if (time.Hour == 20)
            {
                Dispatcher.Dispatch(() => futureStatus.Text = $"{WeatherUtilities.GetWeatherCodeText(weather.hourly.weather_code[i], 0).text} in the evening at {weather.hourly.temperature_2m[i] + weather.hourly_units.temperature_2m}");
                break;
            }
        }
    }

    void GenerateDailyWeatherCrads(WeatherData weather)
    {
        //dailyForecats
        Dispatcher.Dispatch(() => forecastDaily.Children.Clear());
        for (int i = 0; i < weather.daily.time.Length; i++)
        {
            DateTime day = DateTime.Parse(weather.daily.time[i]);
            double opacity = 1;
            string weekDay = day.DayOfWeek.ToString();
            if (i == 0)
            {
                weekDay = "Yesterday";
                opacity = 0.5;
            }
            else if (i == 1)
                weekDay = "Today";

            DailyForecastView dailyForecast = new DailyForecastView
            {
                Day = weekDay,
                Precipitation = weather.daily.precipitation_sum[i] + weather.daily_units.precipitation_sum,
                WeatherCodeIcon = WeatherUtilities.GetWeatherCodeText(weather.daily.weather_code[i], 1).imgPath,
                TemperatureMin = $"{Math.Round(weather.daily.temperature_2m_min[i])}{weather.daily_units.temperature_2m_min}",
                TemperatureMax = $"{Math.Round(weather.daily.temperature_2m_max[i])}{weather.daily_units.temperature_2m_max}",
                Opacity = opacity,
            };
            Dispatcher.Dispatch(() => forecastDaily.Children.Add(dailyForecast));
        }
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

    private void meteoBtn_Clicked(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://open-meteo.com").Wait();
    }
}