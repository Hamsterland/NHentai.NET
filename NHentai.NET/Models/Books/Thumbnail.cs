﻿using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents a thumbnail image for a <see cref="Book"/>.
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// The file extension of the thumbnail.
        /// </summary>
        [JsonPropertyName("t")]
        public string Type { get; set; }
        
        /// <summary>
        /// The pixel width of the thumbnail.
        /// </summary>
        [JsonPropertyName("w")]
        public int Width { get; set; }
                
        
        /// <summary>
        /// The pixel height of the thumbnail.
        /// </summary>
        [JsonPropertyName("h")]
        public int Height { get; set; }
    }
}