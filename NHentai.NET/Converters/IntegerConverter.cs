using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NHentai.NET.Models.Books;

namespace NHentai.NET.Converters
{
    /// <summary>
    /// Represents a class that contains methods to convert Json elements.
    /// </summary>
    public class IntegerConverter : JsonConverter<int>
    {
        /// <summary>
        /// Parses the Id property of <see cref="Book"/> from an <see cref="JsonElement"/> from it deserialized
        /// state of an <see cref="int"/>.
        /// <see cref="JsonElement"/> to an <see cref="int"/>.
        /// </summary>
        /// <param name="reader">The Json reader.</param>
        /// <param name="typeToConvert">The default Json type to be converted.</param>
        /// <param name="options">Json serialization options.</param>
        /// <returns>
        /// A <see cref="Book"/> Id parsed as an <see cref="int"/>.
        /// </returns>
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return reader.GetInt32();
            }
            catch (Exception)
            {
                return int.Parse(reader.GetString());
            }
        }

        // Not implemented.
        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}