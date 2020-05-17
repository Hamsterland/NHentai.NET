using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NHentai.NET.Models.Books;

namespace NHentai.NET.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// Converts the upload date property of a <see cref="Book"/> from a <see cref="JsonElement"/> to a
        /// <see cref="DateTime"/> object during runtime.
        /// </summary>
        /// <remarks>
        /// The default value for this <see cref="JsonElement"/> is a Unix epoch <see cref="int"/>.
        /// </remarks>
        /// <param name="reader">The Json reader.</param>
        /// <param name="typeToConvert">The default Json type to be converted.</param>
        /// <param name="options">Json serialization options.</param>
        /// <returns>
        /// A <see cref="Book"/> upload date parsed as <see cref="DateTime"/>.
        /// </returns>
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