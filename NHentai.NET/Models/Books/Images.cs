﻿﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NHentai.NET.Models.Books
{
    /// <summary>
    /// Represents the images in a <see cref="Book"/>.
    /// </summary>
    public class Images
    {
        /// <summary>
        /// The book pages.
        /// </summary>
        [JsonPropertyName("pages")]
        public List<Image> Pages { get; set; }
        
        /// <summary>
        /// The cover image.
        /// </summary>
        [JsonPropertyName("cover")]
        public Cover Cover { get; set; }
        
        /// <summary>
        /// The thumbnail image.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public Thumbnail Thumbnail { get; set; }
    }
}