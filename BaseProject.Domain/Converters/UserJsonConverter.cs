using System.Text.Json;
using System.Text.Json.Serialization;
using BaseProject.Domain.Models;

namespace BaseProject.Domain.Converters;

public class UserJsonConverter : JsonConverter<User>
{
    public override User? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<User>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}