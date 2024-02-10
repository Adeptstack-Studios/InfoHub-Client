using System.Text.Json;

namespace InfoHub
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Data.Create();
            Utilities.sensors = Data.LoadSensors();
            Utilities.Timer();

            edit.Text = JsonSerializer.Serialize(Utilities.sensors);

            Thread threadSensorData = new Thread(new ThreadStart(ThreadGetSensorData));
            threadSensorData.Start();
        }

        void ThreadGetSensorData()
        {
            foreach (var item in Utilities.sensors)
            {
                if (item.SensorType == SensorType.TemperatureAndPressure)
                {
                    SensorDataTHP sensorData = Web.GetSensorDataTHP(item.IpAddress, item.Port);
                    item.SensorData = sensorData;
                }
            }
        }

        private void NavToSensorsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SensorsPage());
        }
    }
}