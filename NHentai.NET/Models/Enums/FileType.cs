using System.Text.Json.Serialization;
using NHentai.NET.Converters;

namespace NHentai.NET.Models.Enums
{
    /// <summary>
    /// Represents all possible file extensions.
    /// </summary>
    [JsonConverter(typeof(FileConverter))]
    public enum FileType
    {
        /// <summary>
        /// A jpg file type.
        /// </summary>
        Jpg,
        
        /// <summary>
        /// A png file type.
        /// </summary>
        Png
    }
}