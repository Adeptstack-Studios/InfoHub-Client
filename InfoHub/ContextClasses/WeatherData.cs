namespace InfoHub.ContextClasses
{

    public class WeatherData
    {
        public float latitude { get; set; } = 0;
        public float longitude { get; set; } = 0;
        public float generationtime_ms { get; set; } = 0;
        public int utc_offset_seconds { get; set; } = 0;
        public string timezone { get; set; } = "";
        public string timezone_abbreviation { get; set; } = "";
        public float elevation { get; set; } = 0;
        public Current_Units current_units { get; set; } = new Current_Units();
        public Current current { get; set; } = new Current();
        public Hourly_Units hourly_units { get; set; } = new Hourly_Units();
        public Hourly hourly { get; set; } = new Hourly();
        public Daily_Units daily_units { get; set; } = new Daily_Units();
        public Daily daily { get; set; } = new Daily();
    }

    public class Current_Units
    {
        public string time { get; set; } = "";
        public string interval { get; set; } = "";
        public string temperature_2m { get; set; } = "";
        public string relative_humidity_2m { get; set; } = "";
        public string apparent_temperature { get; set; } = "";
        public string is_day { get; set; } = "";
        public string precipitation { get; set; } = "";
        public string rain { get; set; } = "";
        public string showers { get; set; } = "";
        public string snowfall { get; set; } = "";
        public string weather_code { get; set; } = "";
        public string pressure_msl { get; set; } = "";
        public string surface_pressure { get; set; } = "";
        public string wind_speed_10m { get; set; } = "";
        public string wind_direction_10m { get; set; } = "";
    }

    public class Current
    {
        public string time { get; set; } = "";
        public int interval { get; set; } = 0;
        public float temperature_2m { get; set; } = 0;
        public int relative_humidity_2m { get; set; } = 0;
        public float apparent_temperature { get; set; } = 0;
        public int is_day { get; set; } = 0;
        public float precipitation { get; set; } = 0;
        public float rain { get; set; } = 0;
        public float showers { get; set; } = 0;
        public float snowfall { get; set; } = 0;
        public int weather_code { get; set; } = 0;
        public float pressure_msl { get; set; } = 0;
        public float surface_pressure { get; set; } = 0;
        public float wind_speed_10m { get; set; } = 0;
        public int wind_direction_10m { get; set; } = 0;
    }

    public class Hourly_Units
    {
        public string time { get; set; } = "";
        public string temperature_2m { get; set; } = "";
        public string relative_humidity_2m { get; set; } = "";
        public string precipitation { get; set; } = "";
        public string weather_code { get; set; } = "";
    }

    public class Hourly
    {
        public string[] time { get; set; } = new string[192];
        public float[] temperature_2m { get; set; } = new float[192];
        public int[] relative_humidity_2m { get; set; } = new int[192];
        public float[] precipitation { get; set; } = new float[192];
        public int[] weather_code { get; set; } = new int[192];
    }

    public class Daily_Units
    {
        public string time { get; set; } = "";
        public string weather_code { get; set; } = "";
        public string temperature_2m_max { get; set; } = "";
        public string temperature_2m_min { get; set; } = "";
        public string sunrise { get; set; } = "";
        public string sunset { get; set; } = "";
        public string daylight_duration { get; set; } = "";
        public string sunshine_duration { get; set; } = "";
        public string uv_index_max { get; set; } = "";
        public string precipitation_sum { get; set; } = "";
        public string rain_sum { get; set; } = "";
        public string showers_sum { get; set; } = "";
        public string snowfall_sum { get; set; } = "";
        public string precipitation_hours { get; set; } = "";
        public string wind_speed_10m_max { get; set; } = "";
        public string wind_direction_10m_dominant { get; set; } = "";
    }

    public class Daily
    {
        public string[] time { get; set; } = new string[8];
        public int[] weather_code { get; set; } = new int[8];
        public float[] temperature_2m_max { get; set; } = new float[8];
        public float[] temperature_2m_min { get; set; } = new float[8];
        public string[] sunrise { get; set; } = new string[8];
        public string[] sunset { get; set; } = new string[8];
        public float[] daylight_duration { get; set; } = new float[8];
        public float[] sunshine_duration { get; set; } = new float[8];
        public float[] uv_index_max { get; set; } = new float[8];
        public float[] precipitation_sum { get; set; } = new float[8];
        public float[] rain_sum { get; set; } = new float[8];
        public float[] showers_sum { get; set; } = new float[8];
        public float[] snowfall_sum { get; set; } = new float[8];
        public float[] precipitation_hours { get; set; } = new float[8];
        public float[] wind_speed_10m_max { get; set; } = new float[8];
        public int[] wind_direction_10m_dominant { get; set; } = new int[8];
    }

}
