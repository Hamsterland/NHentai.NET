using System.IO;
using System.Text.Json.Serialization;
using NHentai.NET.Converters;

namespace NHentai.NET.Models.Enums
{
    [JsonConverter(typeof(FileConverter))]
    public enum FileType
    {
        Jpg,
        Png
    }
}