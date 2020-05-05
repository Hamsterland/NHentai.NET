﻿using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents the title of a <see cref="Book"/>.
    /// </summary>
    public class Titles
    {
        /// <summary>
        /// The English title.
        /// </summary>
        [JsonPropertyName("english")]
        public string English { get; set; }

        /// <summary>
        /// The Japanese title.
        /// </summary>
        [JsonPropertyName("japanese")]
        public string Japanese { get; set; }

        /// <summary>
        /// The shortened title.
        /// </summary>
        [JsonPropertyName("pretty")]
        public string Pretty { get; set; }
    }
}