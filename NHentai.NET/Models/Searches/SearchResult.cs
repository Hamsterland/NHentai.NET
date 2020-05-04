using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NHentai.NET.Models.Searches
{
    /// <summary>
    /// Represents search results from various queries.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// The list of <see cref="Book"/> that match the query.
        /// </summary>
        [JsonPropertyName("result")]
        public List<Book> Books { get; set; }
        
        /// <summary>
        /// The total number of pages of the query.
        /// </summary>
        [JsonPropertyName("num_pages")]
        public int PagesCount { get; set; }
        
        /// <summary>
        /// The number of pages per count of the query.
        /// </summary>
        /// <remarks>
        /// No, I don't know what this means either.
        /// </remarks>
        [JsonPropertyName("per_page")] 
        public int PerPageCount { get; set; }
    }
}