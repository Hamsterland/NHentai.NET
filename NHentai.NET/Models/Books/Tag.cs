﻿﻿using System.Text.Json.Serialization;

namespace NHentai.NET.Models.Books
{
    /// <summary>
    /// Represents the tags of a <see cref="Book"/>.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// The tag Id.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// The tag type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        /// <summary>
        /// The tag name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The tag url.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// The tag count.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}