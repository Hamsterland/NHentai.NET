﻿using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents a book entry. 
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The Json Id of book.
        /// </summary>
        /// <remarks>
        /// This property should be an <see cref="JsonElement"/> by default and parsed as an integer later.
        /// </remarks>
        [JsonPropertyName("id")]
        public JsonElement JsonId { get; set; }

        /// <summary>
        /// The media JsonId of the book.
        /// </summary>
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// The titles of the book.
        /// </summary>
        [JsonPropertyName("title")]
        public Titles Titles { get; set; }
        
        /// <summary>
        /// The images of the book.
        /// </summary>
        [JsonPropertyName("images")]
        public Images Images { get; set; }
        
        /// <summary>
        /// The scanlation group of the book.
        /// </summary>
        [JsonPropertyName("scanlator")]
        public string Scanlator { get; set; }

        /// <summary>
        /// The upload date of the book.
        /// </summary>
        [JsonPropertyName("upload_date")]
        public int UploadDate { get; set; }

        /// <summary>
        /// The tags of the book.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// The number of pages of the book.
        /// </summary>
        [JsonPropertyName("num_pages")]
        public int PagesCount { get; set; }

        /// <summary>
        /// The number of favorites of the book.
        /// </summary>
        [JsonPropertyName("num_favorites")]
        public int FavoritesCount { get; set; }
    }
}