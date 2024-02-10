namespace InfoHub;

public partial class WeatherLocationsView : ContentView
{

    public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(WeatherLocationsView), string.Empty);
    public static readonly BindableProperty LongitudeProperty = BindableProperty.Create(nameof(Longitude), typeof(string), typeof(WeatherLocationsView), string.Empty);
    public static readonly BindableProperty LatitudeProperty = BindableProperty.Create(nameof(Latitude), typeof(string), typeof(WeatherLocationsView), string.Empty);
    public static readonly BindableProperty MainProperty = BindableProperty.Create(nameof(Main), typeof(bool), typeof(WeatherLocationsView), false);
    public event ClickedEventArgs Clicked;

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
    public bool Main
    {
        get => (bool)GetValue(WeatherLocationsView.MainProperty);
        set => SetValue(WeatherLocationsView.MainProperty, value);
    }

    public WeatherLocationsView()
    {
        InitializeComponent();
    }

    private void optionsBtn_Clicked(object sender, EventArgs e)
    {
        int id = 0;
        int index = 0;
        for (int i = 0; i < Utilities.settings.WeatherSettings.Count; i++)
        {
            if (Utilities.settings.WeatherSettings[i].Name == Name)
            {
                id = Utilities.settings.WeatherSettings[i].ID;
                index = i;
                break;
            }
        }

        InContentViewClickedEventArgs args = new InContentViewClickedEventArgs()
        {
            Index = index,
            ID = id,
            Name = Name,
        };
        Clicked?.Invoke(this, args);
    }
}