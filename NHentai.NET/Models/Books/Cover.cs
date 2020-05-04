﻿using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents a cover image for a <see cref="Book"/>.
    /// </summary>
    public class Cover
    {
        /// <summary>
        /// The file extension of the cover.
        /// </summary>
        [JsonPropertyName("t")]
        public string Type { get; set; }
        
        /// <summary>
        /// The pixel width of the cover.
        /// </summary>
        [JsonPropertyName("w")]
        public int Width { get; set; }
                
        
        /// <summary>
        /// The pixel height of the cover.
        /// </summary>
        [JsonPropertyName("h")]
        public int Height { get; set; }
    }
}