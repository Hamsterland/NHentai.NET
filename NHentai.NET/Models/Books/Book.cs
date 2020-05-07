﻿using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using NHentai.NET.Converters;
 
namespace NHentai.NET.Models.Books
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The book Json Id.
        /// </summary>
        /// <remarks>
        /// This property should be a <see cref="JsonElement"/> by default and parsed as an integer later.
        /// </remarks>
        [JsonPropertyName("id")]
        [JsonConverter(typeof(IntegerConverter))]
        public int Id { get; set; }

        /// <summary>
        /// The book media Id.
        /// </summary>
        /// <remarks>
        /// This property should be a <see cref="string"/> and optionally parsed as an integer later.
        /// </remarks>
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// The book titles.
        /// </summary>
        [JsonPropertyName("title")]
        public Titles Titles { get; set; }
        
        /// <summary>
        /// The book images.
        /// </summary>
        [JsonPropertyName("images")]
        public Images Images { get; set; }
        
        /// <summary>
        /// The book scanlation group.
        /// </summary>
        [JsonPropertyName("scanlator")]
        public string Scanlator { get; set; }

        /// <summary>
        /// The book upload date.
        /// </summary>
        /// <remarks>
        /// This property is currently an <see cref="int"/> when parsed. DatTime parsing to be implemented later.
        /// </remarks>
        [JsonPropertyName("upload_date")]
        public int UploadDate { get; set; }

        /// <summary>
        /// The book tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// The book number of pages.
        /// </summary>
        [JsonPropertyName("num_pages")]
        public int PagesCount { get; set; }

        /// <summary>
        /// The book number of favorites.
        /// </summary>
        [JsonPropertyName("num_favorites")]
        public int FavoritesCount { get; set; }
    }
}