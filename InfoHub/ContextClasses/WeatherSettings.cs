using InfoHub.Enums;

namespace InfoHub.ContextClasses
{
    public class WeatherSettings
    {
        public TemperatureUnit TemperatureUnit { get; set; } = TemperatureUnit.celsius;
        public SpeedUnit SpeedUnit { get; set; } = SpeedUnit.kmh;
    }
}
