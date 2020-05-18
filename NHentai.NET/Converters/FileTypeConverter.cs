using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NHentai.NET.Models.Books;

namespace NHentai.NET.Converters
{
    /// <summary>
    /// Represents a class that contains methods to convert Json elements.
    /// </summary>
    public class FileTypeConverter : JsonConverter<FileType>
    {
        /// <summary>
        /// Converts the file type property of an <see cref="Image"/> from a <see cref="JsonElement"/> to a
        /// <see cref="FileType"/> during runtime.
        /// </summary>
        /// <remarks>
        /// The default value for this <see cref="JsonElement"/> is a <see cref="string"/>.
        /// </remarks>
        /// <param name="reader">The Json reader.</param>
        /// <param name="typeToConvert">The default Json type to be converted.</param>
        /// <param name="options">Json serialization options.</param>
        /// <returns>
        /// An <see cref="Image"/> file extension parsed as <see cref="FileType"/>.
        /// </returns>
        public override FileType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "j" => FileType.Jpg,
                "p" => FileType.Png,
                "g" => FileType.Gif,
                _ => throw new Exception("Could not find a valid file extension.")
            };
        }
        
        // Not implemented.
        public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}