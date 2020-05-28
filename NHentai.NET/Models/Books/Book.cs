﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NHentai.NET.Client;
using NHentai.NET.Converters;
 
namespace NHentai.NET.Models.Books
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The book Id.
        /// </summary>
        [JsonPropertyName("id")]
        [JsonConverter(typeof(IntegerConverter))]
        public int Id { get; set; }

        /// <summary>
        /// The book media Id.
        /// </summary>
        [JsonPropertyName("media_id")]
        [JsonConverter(typeof(IntegerConverter))]
        public int MediaId { get; set; }

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
        [JsonPropertyName("upload_date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UploadDate { get; set; }

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

        /// <summary>
        /// Generates links for all pages in a <see cref="Book"/> through iteration.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of page links.
        /// </returns>
        public IEnumerable<string> GetPages()
        {
            var pages = new List<string>();
            
            for (var i = 1; i < PagesCount; i++)
            {
                pages.Add(GetPage(i));
            }
            
            return pages;
        }
        
        /// <summary>
        /// Generates a link for a certain page in a <see cref="Book"/>.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <returns>
        /// A page link.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown if the specified page number is outside the bounds of the book.
        /// </exception>
        public string GetPage(int page)
        {
            if (page <= 0 || page > PagesCount)
            {
                throw new IndexOutOfRangeException("The page number you specified is outside the bounds of this book.");
            }
            
            return $"{HentaiConfig.ImageApiRoot}{string.Format(HentaiConfig.PageSearchRoot, MediaId, page, Images.Pages[page - 1].Type.ToString().ToLower())}";
        }
        
        /// <summary>
        /// Generates a link for the cover image of <see cref="Book"/>.
        /// </summary>
        /// <returns>
        /// A cover link.
        /// </returns>
        public string GetCover()
        {
            return string.Format(HentaiConfig.CoverImageRoot, MediaId, Images.Cover.Type.ToString().ToLower());
        }
    }
}