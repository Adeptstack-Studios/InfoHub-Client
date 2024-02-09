namespace InfoHub;

public partial class SensorsPage : ContentPage
{
    List<Sensors> sensors = new List<Sensors>();

    public SensorsPage()
    {
        InitializeComponent();
        sensors = Data.LoadSensors();
    }

    private void refresh_Refreshing(object sender, EventArgs e)
    {
        if (ShowSensorsData())
        {
            refresh.IsRefreshing = false;
        }
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
        if (sensors.Count > 0)
        {
            id = sensors[sensors.Count - 1].ID + 1;
        }

        sensors.Add(new Sensors
        {
            ID = id,
            Name = nameEntry.Text,
            IpAddress = ipEntry.Text,
            Port = portEntry.Text,
            SensorType = (SensorType)typePicker.SelectedIndex
        });

        Data.SaveSensors(sensors);
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
        foreach (var item in sensors)
        {
            if (item.SensorType == SensorType.TemperatureAndPressure)
            {
                SensorDataTHP sensorData = Web.GetSensorDataTHP(item.IpAddress, item.Port);
                item.SensorData = sensorData;

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
        return true;
    }

    private void AddButton_Loaded(object sender, EventArgs e)
    {
        ShowSensorsData();
    }
}