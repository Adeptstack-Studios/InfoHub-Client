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
    }
}
