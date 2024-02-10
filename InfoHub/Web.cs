using System.Net.Http.Headers;
using System.Text.Json;

namespace InfoHub
{
    class Web
    {
        static HttpClient client = new HttpClient();

        public static SensorDataTHP GetSensorDataTHP(string ip, string port)
        {
            SensorDataTHP sensorData;

            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Version", "1");

                var stringTask = client.GetStringAsync($"http://{ip}:{port}/GetCurrentValues");
                string getJson = stringTask.Result;
                sensorData = JsonSerializer.Deserialize<SensorDataTHP>(getJson) ?? new();
            }
            catch (Exception e)
            {
                sensorData = new SensorDataTHP();
                sensorData.temperature = 10;
            }
            return sensorData;
        }

        public static WeatherData GetWeatherData(string latitude, string longitude)
        {
            WeatherData weather;

            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Version", "1");

                var stringTask = client.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,is_day,precipitation,rain,showers,snowfall,weather_code,pressure_msl,surface_pressure,wind_speed_10m,wind_direction_10m&daily=temperature_2m_max,temperature_2m_min,sunrise,sunset,daylight_duration,sunshine_duration,uv_index_max,precipitation_sum,rain_sum,showers_sum,snowfall_sum,precipitation_hours,wind_speed_10m_max,wind_direction_10m_dominant&timezone=auto&forecast_days=3");
                string getJson = stringTask.Result;
                weather = JsonSerializer.Deserialize<WeatherData>(getJson) ?? new();
            }
            catch (Exception e)
            {
                weather = new();
            }
            return weather;
        }
    }
}
