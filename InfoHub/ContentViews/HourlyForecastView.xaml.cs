using System.Diagnostics;

namespace InfoHub.ContentViews;

public partial class HourlyForecastView : ContentView
{
    public static readonly BindableProperty TimeProperty = BindableProperty.Create(nameof(Time), typeof(string), typeof(HourlyForecastView), string.Empty);
    public static readonly BindableProperty WeatherCodeIconProperty = BindableProperty.Create(nameof(WeatherCodeIcon), typeof(string), typeof(HourlyForecastView), string.Empty);
    public static readonly BindableProperty TemperatureProperty = BindableProperty.Create(nameof(Temperature), typeof(string), typeof(HourlyForecastView), string.Empty);
    public static readonly BindableProperty HumidityProperty = BindableProperty.Create(nameof(Humidity), typeof(string), typeof(HourlyForecastView), string.Empty);
    public static event ClickedEventArgs Clicked;

    public string Time
    {
        get => (string)GetValue(HourlyForecastView.TimeProperty);
        set => SetValue(HourlyForecastView.TimeProperty, value);
    }
    public string WeatherCodeIcon
    {
        get => (string)GetValue(HourlyForecastView.WeatherCodeIconProperty);
        set => SetValue(HourlyForecastView.WeatherCodeIconProperty, value);
    }
    public string Temperature
    {
        get => (string)GetValue(HourlyForecastView.TemperatureProperty);
        set => SetValue(HourlyForecastView.TemperatureProperty, value);
    }
    public string Humidity
    {
        get => (string)GetValue(HourlyForecastView.HumidityProperty);
        set => SetValue(HourlyForecastView.HumidityProperty, value);
    }

    public HourlyForecastView()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception e)
        {
            string exce = e.InnerException + Environment.NewLine + e.Message;
            Console.WriteLine(exce);
            Debug.WriteLine(exce);
            System.Diagnostics.Debugger.Log(1, "Important", exce);
            throw new Exception(exce);
        }
    }
}