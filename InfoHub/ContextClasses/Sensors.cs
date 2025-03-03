using InfoHub.Enums;
using System.Text.Json.Serialization;

namespace InfoHub.ContextClasses
{
    public class Sensors
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public SensorType SensorType { get; set; }

        [JsonConverter(typeof(SensorDataConverter))]
        public SensorData SensorData { get; set; }
    }
}
