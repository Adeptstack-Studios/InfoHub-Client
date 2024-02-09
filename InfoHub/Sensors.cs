namespace InfoHub
{
    public class Sensors
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public SensorType SensorType { get; set; }
        public SensorDataTHP SensorData { get; set; }
    }
}
