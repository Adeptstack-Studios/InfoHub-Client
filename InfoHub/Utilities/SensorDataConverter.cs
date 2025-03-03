using InfoHub.ContextClasses;
using System.Text.Json;
using System.Text.Json.Serialization;

public class SensorDataConverter : JsonConverter<SensorData>
{
    public override SensorData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            if (!root.TryGetProperty("Type", out JsonElement typeElement))
            {
                throw new JsonException("Missing Type property for SensorData.");
            }

            string typeName = typeElement.GetString();
            return typeName switch
            {
                nameof(SensorDataTHP) => JsonSerializer.Deserialize<SensorDataTHP>(root.GetRawText(), options),
                nameof(SensorDataDC) => JsonSerializer.Deserialize<SensorDataDC>(root.GetRawText(), options),
                _ => throw new JsonException($"Unknown SensorData type: {typeName}")
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, SensorData value, JsonSerializerOptions options)
    {
        var typeName = value.GetType().Name;
        using (JsonDocument doc = JsonDocument.Parse(JsonSerializer.Serialize(value, value.GetType(), options)))
        {
            writer.WriteStartObject();
            writer.WriteString("Type", typeName);  // Speichert den Typ als zusätzliche Eigenschaft
            foreach (var property in doc.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
            writer.WriteEndObject();
        }
    }
}
