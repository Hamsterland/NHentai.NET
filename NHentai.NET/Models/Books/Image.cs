﻿using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents an image page for a <see cref="Book"/>.
    /// </summary>
    public class Image
    {
       
        /// <summary>
        /// The file extension of the image.
        /// </summary>
        [JsonPropertyName("t")]
        public string Type { get; set; }
        
        /// <summary>
        /// The pixel width of the image.
        /// </summary>
        [JsonPropertyName("w")]
        public int Width { get; set; }
                
        
        /// <summary>
        /// The pixel height of the image.
        /// </summary>
        [JsonPropertyName("h")]
        public int Height { get; set; }
    }
}