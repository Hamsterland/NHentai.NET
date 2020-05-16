﻿﻿using System.IO;
 using System.Text.Json.Serialization;
 using NHentai.NET.Converters;
 using NHentai.NET.Models.Enums;

 namespace NHentai.NET.Models.Books
{
    /// <summary>
    /// Represents an image page for a <see cref="Book"/>.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// The image file extension.
        /// </summary>
        [JsonPropertyName("t")]
        [JsonConverter(typeof(FileTypeConverter))]
        public FileType Type { get; set; }
        
        /// <summary>
        /// The image pixel width.
        /// </summary>
        [JsonPropertyName("w")]
        public int Width { get; set; }


        /// <summary>
        /// The image pixel height.
        /// </summary>
        [JsonPropertyName("h")]
        public int Height { get; set; }
    }
}