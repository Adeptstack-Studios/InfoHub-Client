namespace InfoHub
{
    public class Settings
    {
        public List<WeatherLocations> WeatherSettings { get; set; } = new List<WeatherLocations>();
    }

    public class WeatherLocations
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Main { get; set; }
    }
}
