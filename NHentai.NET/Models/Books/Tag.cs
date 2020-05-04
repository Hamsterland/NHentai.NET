﻿using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents the tags of a <see cref="Book"/>.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// The Id of the tag.
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        
        /// <summary>
        /// The type of tag.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        /// <summary>
        /// The name of the tag.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The url of the tag.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// The count of the tag.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}