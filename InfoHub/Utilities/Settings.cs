using InfoHub.ContextClasses;

namespace InfoHub.Utilities
{
    public class Settings
    {
        public List<WeatherLocations> WeatherLocations { get; set; } = new List<WeatherLocations>();
        public WeatherSettings WeatherSettings { get; set; } = new WeatherSettings();
    }
}
