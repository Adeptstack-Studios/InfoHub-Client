using InfoHub.ContentViews;
using InfoHub.ContextClasses;
using InfoHub.CustomEventArgs;
using InfoHub.Enums;
using InfoHub.Utilities;

namespace InfoHub.Pages;

public partial class SensorsPage : ContentPage
{
    int index = 0;
    bool isEdit = false;
    public SensorsPage()
    {
        InitializeComponent();
        Thread sensorCards = new Thread(new ThreadStart(GenerateSensorCard));
        sensorCards.Start();
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
            if (Utilities.AppResources.sensors.Count > 0)
            {
                id = Utilities.AppResources.sensors[Utilities.AppResources.sensors.Count - 1].ID + 1;
            }

            Utilities.AppResources.sensors.Add(new Sensors
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
            Utilities.AppResources.sensors[index].Name = nameEntry.Text;
            Utilities.AppResources.sensors[index].IpAddress = ipEntry.Text;
            Utilities.AppResources.sensors[index].Port = portEntry.Text;
            Utilities.AppResources.sensors[index].SensorType = (SensorType)typePicker.SelectedIndex;
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
        Data.SaveSensors(Utilities.AppResources.sensors);
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

    void ShowSensorsData()
    {
        Thread sensorCards = new Thread(new ThreadStart(GenerateSensorCard));
        sensorCards.Start();
    }

    void GenerateSensorCard()
    {
        Dispatcher.Dispatch(() => flexl.Children.Clear());
        foreach (var item in Utilities.AppResources.sensors)
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

                Dispatcher.Dispatch(() => flexl.Children.Add(sensorCard));
            }
        }
        Data.SaveSensors(Utilities.AppResources.sensors);
        Dispatcher.Dispatch(() => refresh.IsRefreshing = false);
    }

    private void OptionsBtnClicked(object sender, InContentViewClickedEventArgs e)
    {
        index = e.Index;
        isEdit = true;
        refresh.IsEnabled = false;
        scroll.IsEnabled = false;
        AddDialog.IsVisible = true;
        AddDialog.IsEnabled = true;

        var values = Utilities.AppResources.sensors[e.Index];
        dialogTitle.Text = $"Edit {values.Name}";

        nameEntry.Text = values.Name;
        ipEntry.Text = values.IpAddress;
        portEntry.Text = values.Port;
        typePicker.SelectedIndex = (int)values.SensorType;
    }

    private void AddButton_Loaded(object sender, EventArgs e)
    {
        //ShowSensorsData();
    }

    private void DeleteSensorBtn_Clicked(object sender, EventArgs e)
    {
        int index = GetIndexOfSameSensor();

        if (index >= 0)
        {
            Utilities.AppResources.sensors.RemoveAt(index);

            nameEntry.Text = "";
            ipEntry.Text = "";
            portEntry.Text = "";
            typePicker.SelectedIndex = -1;
            refresh.IsEnabled = true;
            scroll.IsEnabled = true;
            AddDialog.IsVisible = false;
            AddDialog.IsEnabled = false;
            isEdit = false;
            Data.SaveSensors(Utilities.AppResources.sensors);
            ShowSensorsData();
        }
    }

    int GetIndexOfSameSensor()
    {
        int index = 0;
        for (int i = 0; i < Utilities.AppResources.sensors.Count; i++)
        {
            if (nameEntry.Text == Utilities.AppResources.sensors[i].Name && ipEntry.Text == Utilities.AppResources.sensors[i].IpAddress && portEntry.Text == Utilities.AppResources.sensors[i].Port && typePicker.SelectedIndex == (int)Utilities.AppResources.sensors[i].SensorType)
            {
                index = i;
                return index;
            }
        }
        return -1;
    }

    int CheckSensorMatches()
    {
        foreach (var item in Utilities.AppResources.sensors)
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