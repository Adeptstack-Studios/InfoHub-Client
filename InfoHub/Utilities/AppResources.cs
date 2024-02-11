using InfoHub.ContextClasses;
using InfoHub.Enums;

namespace InfoHub.Utilities
{
    public class AppResources
    {
        public static List<Sensors> sensors = new List<Sensors>();
        public static Settings settings = new Settings();

        public static void Timer()
        {
            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(60);
            timer.Tick += (s, e) =>
            {
                Thread threadSensorData = new Thread(new ThreadStart(ThreadGetSensorData));
                threadSensorData.Start();
            };
            timer.Start();
        }

        private static void ThreadGetSensorData()
        {
            try
            {
                foreach (var item in sensors)
                {
                    if (item.SensorType == SensorType.TemperatureAndPressure)
                    {
                        SensorDataTHP sensorData = Web.GetSensorDataTHP(item.IpAddress, item.Port);
                        item.SensorData = sensorData;
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
