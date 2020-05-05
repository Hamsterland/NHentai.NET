using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using NHentai.NET.Models.Enums;

namespace NHentai.NET.Converters
{
    public class FileConverter : JsonConverter<FileType>
    {
        public override FileType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "j" => FileType.Jpg,
                "p" => FileType.Png,
                _ => throw new Exception("Could not find a valid file extension.")
            };
        }

        public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}