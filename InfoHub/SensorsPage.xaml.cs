namespace InfoHub;

public partial class SensorsPage : ContentPage
{
    int index = 0;
    bool isEdit = false;
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
        dialogTitle.Text = "Add new Sensor";
        isEdit = false;
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

        if (CheckSensorMatches() == 0 && !isEdit)
        {
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
        }
        else if (isEdit && CheckSensorMatches() == 0)
        {
            Utilities.sensors[index].Name = nameEntry.Text;
            Utilities.sensors[index].IpAddress = ipEntry.Text;
            Utilities.sensors[index].Port = portEntry.Text;
            Utilities.sensors[index].SensorType = (SensorType)typePicker.SelectedIndex;
        }
        else if (CheckSensorMatches() == 1)
        {
            lblMessage.Text = "The sensor with this data already exists!";
            message.IsVisible = true;
        }

        isEdit = false;
        nameEntry.Text = "";
        ipEntry.Text = "";
        portEntry.Text = "";
        typePicker.SelectedIndex = -1;
        Data.SaveSensors(Utilities.sensors);
        ShowSensorsData();
    }

    private void CancelSensorBtn_Clicked(object sender, EventArgs e)
    {
        refresh.IsEnabled = true;
        scroll.IsEnabled = true;
        AddDialog.IsVisible = false;
        AddDialog.IsEnabled = false;
        isEdit = false;
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
                sensorCard.Clicked += OptionsBtnClicked;

                flexl.Children.Add(sensorCard);
            }
        }
        Data.SaveSensors(Utilities.sensors);
        refresh.IsRefreshing = false;
        return true;
    }

    private void OptionsBtnClicked(object sender, InContentViewClickedEventArgs e)
    {
        index = e.Index;
        isEdit = true;
        refresh.IsEnabled = false;
        scroll.IsEnabled = false;
        AddDialog.IsVisible = true;
        AddDialog.IsEnabled = true;

        var values = Utilities.sensors[e.Index];
        dialogTitle.Text = $"Edit {values.Name}";

        nameEntry.Text = values.Name;
        ipEntry.Text = values.IpAddress;
        portEntry.Text = values.Port;
        typePicker.SelectedIndex = (int)values.SensorType;
    }

    private void AddButton_Loaded(object sender, EventArgs e)
    {
        ShowSensorsData();
    }

    private void DeleteSensorBtn_Clicked(object sender, EventArgs e)
    {
        int index = GetIndexOfSameSensor();

        if (index >= 0)
        {
            Utilities.sensors.RemoveAt(index);

            nameEntry.Text = "";
            ipEntry.Text = "";
            portEntry.Text = "";
            typePicker.SelectedIndex = -1;
            refresh.IsEnabled = true;
            scroll.IsEnabled = true;
            AddDialog.IsVisible = false;
            AddDialog.IsEnabled = false;
            isEdit = false;
            Data.SaveSensors(Utilities.sensors);
            ShowSensorsData();
        }
    }

    int GetIndexOfSameSensor()
    {
        int index = 0;
        for (int i = 0; i < Utilities.sensors.Count; i++)
        {
            if (nameEntry.Text == Utilities.sensors[i].Name && ipEntry.Text == Utilities.sensors[i].IpAddress && portEntry.Text == Utilities.sensors[i].Port && typePicker.SelectedIndex == (int)Utilities.sensors[i].SensorType)
            {
                index = i;
                return index;
            }
        }
        return -1;
    }

    int CheckSensorMatches()
    {
        foreach (var item in Utilities.sensors)
        {
            if (nameEntry.Text == item.Name && ipEntry.Text == item.IpAddress && portEntry.Text == item.Port && typePicker.SelectedIndex == (int)item.SensorType)
            {
                return 1;
            }
        }
        return 0;
    }

    private void OKBtn_Clicked(object sender, EventArgs e)
    {
        message.IsVisible = false;
    }
}