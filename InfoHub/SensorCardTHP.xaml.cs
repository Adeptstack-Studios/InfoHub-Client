namespace InfoHub;

public partial class SensorCardTHP : ContentView
{
    public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(SensorCardTHP), string.Empty);
    public static readonly BindableProperty TemperatureProperty = BindableProperty.Create(nameof(Temperature), typeof(string), typeof(SensorCardTHP), string.Empty);
    public static readonly BindableProperty HumidityProperty = BindableProperty.Create(nameof(Humidity), typeof(string), typeof(SensorCardTHP), string.Empty);
    public static readonly BindableProperty PressureProperty = BindableProperty.Create(nameof(Pressure), typeof(string), typeof(SensorCardTHP), string.Empty);
    public static readonly BindableProperty AltitudeProperty = BindableProperty.Create(nameof(Altitude), typeof(string), typeof(SensorCardTHP), string.Empty);

    public string Name
    {
        get => (string)GetValue(SensorCardTHP.NameProperty);
        set => SetValue(SensorCardTHP.NameProperty, value);
    }
    public string Temperature
    {
        get => (string)GetValue(SensorCardTHP.TemperatureProperty);
        set => SetValue(SensorCardTHP.TemperatureProperty, value);
    }
    public string Humidity
    {
        get => (string)GetValue(SensorCardTHP.HumidityProperty);
        set => SetValue(SensorCardTHP.HumidityProperty, value);
    }
    public string Pressure
    {
        get => (string)GetValue(SensorCardTHP.PressureProperty);
        set => SetValue(SensorCardTHP.PressureProperty, value);
    }
    public string Altitude
    {
        get => (string)GetValue(SensorCardTHP.AltitudeProperty);
        set => SetValue(SensorCardTHP.AltitudeProperty, value);
    }

    public SensorCardTHP()
    {
        InitializeComponent();
    }
}