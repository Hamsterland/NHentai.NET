using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NHentai.NET.Models.Books;
using NHentai.NET.Models.Enums;

namespace NHentai.NET.Converters
{
    /// <summary>
    /// Represents a class that contains methods to convert Json elements.
    /// </summary>
    public class FileConverter : JsonConverter<FileType>
    {
        /// <summary>
        /// Converts the file extension of an <see cref="Image"/> from a <see cref="string"/> to a <see cref="FileType"/>
        /// enum during runtime.
        /// </summary>
        /// <param name="reader">The Json reader.</param>
        /// <param name="typeToConvert">The default Json type to be converted.</param>
        /// <param name="options">Json serialization options.</param>
        /// <returns>
        /// An <see cref="Image"/> file extension as a <see cref="FileType"/>.
        /// </returns>
        public override FileType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "j" => FileType.Jpg,
                "p" => FileType.Png,
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