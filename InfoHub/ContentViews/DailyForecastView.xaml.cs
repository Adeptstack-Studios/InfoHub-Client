using System.Diagnostics;
using System.Reflection;

namespace InfoHub.ContentViews;

public partial class DailyForecastView : ContentView
{
    public static readonly BindableProperty DayProperty = BindableProperty.Create(nameof(Day), typeof(string), typeof(DailyForecastView), string.Empty);
    public static readonly BindableProperty PrecipitationProperty = BindableProperty.Create(nameof(Precipitation), typeof(string), typeof(DailyForecastView), string.Empty);
    public static readonly BindableProperty WeatherCodeIconProperty = BindableProperty.Create(nameof(WeatherCodeIcon), typeof(string), typeof(DailyForecastView), string.Empty);
    public static readonly BindableProperty TemperatureMinProperty = BindableProperty.Create(nameof(TemperatureMin), typeof(string), typeof(DailyForecastView), string.Empty);
    public static readonly BindableProperty TemperatureMaxProperty = BindableProperty.Create(nameof(TemperatureMax), typeof(string), typeof(DailyForecastView), string.Empty);

    public string Day
    {
        get => (string)GetValue(DailyForecastView.DayProperty);
        set => SetValue(DailyForecastView.DayProperty, value);
    }
    public string Precipitation
    {
        get => (string)GetValue(DailyForecastView.PrecipitationProperty);
        set => SetValue(DailyForecastView.PrecipitationProperty, value);
    }
    public string WeatherCodeIcon
    {
        get => (string)GetValue(DailyForecastView.WeatherCodeIconProperty);
        set => SetValue(DailyForecastView.WeatherCodeIconProperty, value);
    }
    public string TemperatureMin
    {
        get => (string)GetValue(DailyForecastView.TemperatureMinProperty);
        set => SetValue(DailyForecastView.TemperatureMinProperty, value);
    }
    public string TemperatureMax
    {
        get => (string)GetValue(DailyForecastView.TemperatureMaxProperty);
        set => SetValue(DailyForecastView.TemperatureMaxProperty, value);
    }

    public DailyForecastView()
    {
        try
        {
            InitializeComponent();
        }
        catch (TargetInvocationException e)
        {
            string exce = e.InnerException + Environment.NewLine + e.Message;
            Console.WriteLine(exce);
            Debug.WriteLine(exce);
            System.Diagnostics.Debugger.Log(1, "Important", exce);
            throw new Exception(exce);
        }
    }
}