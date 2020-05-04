using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NHentai.NET.Models
{
    /// <summary>
    /// Represents a book entry. 
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The Id of book.
        /// </summary>
        /// <remarks>
        /// This property is an <see cref="object"/> because this API wrapper uses <see cref="System.Text.Json"/> instead
        /// of Newtonsoft. The in-built system does not support deserializing numbers in quotations marks as integers.
        /// Therefore, since NHentai's API frequently has book Id's as strings, it is more efficient to use a general type
        /// and parse the Id as an integer later is more efficient.
        /// </remarks>
        [JsonPropertyName("id")]
        public object Id { get; set; }
        
        /// <summary>
        /// The media Id of the book.
        /// </summary>
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// The titles of the book.
        /// </summary>
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        
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