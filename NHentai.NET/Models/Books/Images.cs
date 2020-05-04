﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents the images in a <see cref="Book"/>.
    /// </summary>
    public class Images
    {
        /// <summary>
        /// The bulk content of the images.
        /// </summary>
        [JsonPropertyName("pages")]
        public List<Image> Pages { get; set; }
        
        /// <summary>
        /// The cover image of the images.
        /// </summary>
        [JsonPropertyName("cover")]
        public Cover Cover { get; set; }
        
        /// <summary>
        /// The thumbnail of the images.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public Thumbnail Thumbnail { get; set; }
    }
}