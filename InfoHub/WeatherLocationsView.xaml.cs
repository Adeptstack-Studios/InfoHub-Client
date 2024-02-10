namespace InfoHub;

public partial class WeatherLocationsView : ContentView
{

    public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(WeatherLocationsView), string.Empty);
    public static readonly BindableProperty LongitudeProperty = BindableProperty.Create(nameof(Longitude), typeof(string), typeof(WeatherLocationsView), string.Empty);
    public static readonly BindableProperty LatitudeProperty = BindableProperty.Create(nameof(Latitude), typeof(string), typeof(WeatherLocationsView), string.Empty);

    public string Name
    {
        get => (string)GetValue(WeatherLocationsView.NameProperty);
        set => SetValue(WeatherLocationsView.NameProperty, value);
    }
    public string Latitude
    {
        get => (string)GetValue(WeatherLocationsView.LatitudeProperty);
        set => SetValue(WeatherLocationsView.LatitudeProperty, value);
    }
    public string Longitude
    {
        get => (string)GetValue(WeatherLocationsView.LongitudeProperty);
        set => SetValue(WeatherLocationsView.LongitudeProperty, value);
    }

    public WeatherLocationsView()
    {
        InitializeComponent();
    }
}