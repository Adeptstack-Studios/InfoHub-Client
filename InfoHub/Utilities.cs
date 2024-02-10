namespace InfoHub
{
    public class Utilities
    {
        public static List<Sensors> sensors = new List<Sensors>();

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
            foreach (var item in Utilities.sensors)
            {
                if (item.SensorType == SensorType.TemperatureAndPressure)
                {
                    SensorDataTHP sensorData = Web.GetSensorDataTHP(item.IpAddress, item.Port);
                    item.SensorData = sensorData;
                }
            }
        }
    }
}
