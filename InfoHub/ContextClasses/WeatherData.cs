namespace InfoHub.ContextClasses
{


    public class WeatherData
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public float elevation { get; set; }
        public Current_Units current_units { get; set; }
        public Current current { get; set; }
        public Daily_Units daily_units { get; set; }
        public Daily daily { get; set; }
    }

    public class Current_Units
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temperature_2m { get; set; }
        public string relative_humidity_2m { get; set; }
        public string is_day { get; set; }
        public string precipitation { get; set; }
        public string rain { get; set; }
        public string showers { get; set; }
        public string snowfall { get; set; }
        public string weather_code { get; set; }
        public string pressure_msl { get; set; }
        public string surface_pressure { get; set; }
        public string wind_speed_10m { get; set; }
        public string wind_direction_10m { get; set; }
    }

    public class Current
    {
        public string time { get; set; }
        public int interval { get; set; }
        public float temperature_2m { get; set; }
        public int relative_humidity_2m { get; set; }
        public int is_day { get; set; }
        public float precipitation { get; set; }
        public float rain { get; set; }
        public float showers { get; set; }
        public float snowfall { get; set; }
        public int weather_code { get; set; }
        public float pressure_msl { get; set; }
        public float surface_pressure { get; set; }
        public float wind_speed_10m { get; set; }
        public int wind_direction_10m { get; set; }
    }

    public class Daily_Units
    {
        public string time { get; set; }
        public string temperature_2m_max { get; set; }
        public string temperature_2m_min { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string daylight_duration { get; set; }
        public string sunshine_duration { get; set; }
        public string uv_index_max { get; set; }
        public string precipitation_sum { get; set; }
        public string rain_sum { get; set; }
        public string showers_sum { get; set; }
        public string snowfall_sum { get; set; }
        public string precipitation_hours { get; set; }
        public string wind_speed_10m_max { get; set; }
        public string wind_direction_10m_dominant { get; set; }
    }

    public class Daily
    {
        public string[] time { get; set; }
        public float[] temperature_2m_max { get; set; }
        public float[] temperature_2m_min { get; set; }
        public string[] sunrise { get; set; }
        public string[] sunset { get; set; }
        public float[] daylight_duration { get; set; }
        public float[] sunshine_duration { get; set; }
        public float[] uv_index_max { get; set; }
        public float[] precipitation_sum { get; set; }
        public float[] rain_sum { get; set; }
        public float[] showers_sum { get; set; }
        public float[] snowfall_sum { get; set; }
        public float[] precipitation_hours { get; set; }
        public float[] wind_speed_10m_max { get; set; }
        public int[] wind_direction_10m_dominant { get; set; }
    }


}
