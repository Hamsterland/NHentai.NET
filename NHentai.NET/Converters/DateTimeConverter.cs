using System;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NHentai.NET.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var offset = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32());
            return offset.UtcDateTime;
        }

        // Not Implemented
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}