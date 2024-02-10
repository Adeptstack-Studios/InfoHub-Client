using System.Text.Json;

namespace InfoHub
{
    public class Data
    {
        public static void Create()
        {
            string path = FileSystem.Current.AppDataDirectory;
            string fullPath = Path.Combine(path, "InfoHub");
            string filePath = Path.Combine(fullPath, "sensors.json");
            string settingsPath = Path.Combine(fullPath, "settings.json");

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            if (!File.Exists(settingsPath))
            {
                File.Create(settingsPath).Dispose();
            }
        }

        public static void SaveSensors(List<Sensors> sensors)
        {
            string path = FileSystem.Current.AppDataDirectory;
            string fullPath = Path.Combine(path, "InfoHub");
            string filePath = Path.Combine(fullPath, "sensors.json");

            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(JsonSerializer.Serialize(sensors));
            sw.Close();
        }

        public static List<Sensors> LoadSensors()
        {
            try
            {
                string path = FileSystem.Current.AppDataDirectory;
                string fullPath = Path.Combine(path, "InfoHub");
                string filePath = Path.Combine(fullPath, "sensors.json");

                string json = File.ReadAllText(filePath);
                Console.WriteLine(json);
                return JsonSerializer.Deserialize<List<Sensors>>(json) ?? new();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return new();
            }
        }

        public static void SaveSettings(Settings settings)
        {
            string path = FileSystem.Current.AppDataDirectory;
            string fullPath = Path.Combine(path, "InfoHub");
            string filePath = Path.Combine(fullPath, "settings.json");

            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(JsonSerializer.Serialize(settings));
            sw.Close();
        }

        public static Settings LoadSettings()
        {
            try
            {
                string path = FileSystem.Current.AppDataDirectory;
                string fullPath = Path.Combine(path, "InfoHub");
                string filePath = Path.Combine(fullPath, "settings.json");

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Settings>(json) ?? new();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"{e.Message}");
                return new();
            }
        }
    }
}
