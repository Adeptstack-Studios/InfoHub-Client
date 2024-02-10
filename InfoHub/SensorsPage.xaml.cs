namespace InfoHub;

public partial class SensorsPage : ContentPage
{
    public SensorsPage()
    {
        InitializeComponent();
    }

    private void refresh_Refreshing(object sender, EventArgs e)
    {
        ShowSensorsData();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        refresh.IsEnabled = false;
        scroll.IsEnabled = false;
        AddDialog.IsVisible = true;
        AddDialog.IsEnabled = true;
    }

    private void SaveSensorBtn_Clicked(object sender, EventArgs e)
    {
        refresh.IsEnabled = true;
        scroll.IsEnabled = true;
        AddDialog.IsVisible = false;
        AddDialog.IsEnabled = false;

        int id = 0;
        if (Utilities.sensors.Count > 0)
        {
            id = Utilities.sensors[Utilities.sensors.Count - 1].ID + 1;
        }

        Utilities.sensors.Add(new Sensors
        {
            ID = id,
            Name = nameEntry.Text,
            IpAddress = ipEntry.Text,
            Port = portEntry.Text,
            SensorType = (SensorType)typePicker.SelectedIndex
        });

        Data.SaveSensors(Utilities.sensors);
        ShowSensorsData();
    }

    private void CancelSensorBtn_Clicked(object sender, EventArgs e)
    {
        refresh.IsEnabled = true;
        scroll.IsEnabled = true;
        AddDialog.IsVisible = false;
        AddDialog.IsEnabled = false;
    }

    bool ShowSensorsData()
    {
        flexl.Children.Clear();
        foreach (var item in Utilities.sensors)
        {
            if (item.SensorType == SensorType.TemperatureAndPressure)
            {
                SensorCardTHP sensorCard = new SensorCardTHP
                {
                    Name = item.Name,
                    Temperature = item.SensorData.temperature.ToString() + "°C",
                    Humidity = item.SensorData.humidity.ToString() + "%",
                    Pressure = item.SensorData.pressure.ToString() + "hPa",
                    Altitude = item.SensorData.altitude.ToString() + "m",
                };
                flexl.Children.Add(sensorCard);
            }
        }
        Data.SaveSensors(Utilities.sensors);
        refresh.IsRefreshing = false;
        return true;
    }

    private void AddButton_Loaded(object sender, EventArgs e)
    {
        ShowSensorsData();
    }
}