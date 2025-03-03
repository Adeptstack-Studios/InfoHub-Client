using InfoHub.CustomEventArgs;

namespace InfoHub.ContentViews;

public partial class SensorCardDC : ContentView
{
    public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(SensorCardDC), string.Empty);
    public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(nameof(IsOpen), typeof(bool), typeof(SensorCardDC), false);
    public static readonly BindableProperty IsAlarmProperty = BindableProperty.Create(nameof(IsAlarm), typeof(bool), typeof(SensorCardDC), false);
    public static readonly BindableProperty AlarmProperty = BindableProperty.Create(nameof(Alarm), typeof(bool), typeof(SensorCardDC), false);
    public event ClickedEventArgs Clicked;

    public string Name
    {
        get => (string)GetValue(SensorCardDC.NameProperty);
        set => SetValue(SensorCardDC.NameProperty, value);
    }
    public bool IsOpen
    {
        get => (bool)GetValue(SensorCardDC.IsOpenProperty);
        set => SetValue(SensorCardDC.IsOpenProperty, value);
    }
    public bool IsAlarm
    {
        get => (bool)GetValue(SensorCardDC.IsAlarmProperty);
        set => SetValue(SensorCardDC.IsAlarmProperty, value);
    }
    public bool Alarm
    {
        get => (bool)GetValue(SensorCardDC.AlarmProperty);
        set => SetValue(SensorCardDC.AlarmProperty, value);
    }

    public SensorCardDC()
    {
        InitializeComponent();
    }

    private void optionsBtn_Clicked(object sender, EventArgs e)
    {
        int id = 0;
        int index = 0;
        for (int i = 0; i < Utilities.AppResources.sensors.Count; i++)
        {
            if (Utilities.AppResources.sensors[i].Name == Name)
            {
                id = Utilities.AppResources.sensors[i].ID;
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