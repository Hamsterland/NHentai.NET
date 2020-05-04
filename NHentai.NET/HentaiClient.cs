using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NHentai.NET.Models;
using System.Text.Json;
using NHentai.NET.Models.Searches;

namespace NHentai.NET
{
    /// <summary>
    /// Represents the main class.
    /// </summary>
    public class HentaiClient : IDisposable
    {
        /// <summary>
        /// The <see cref="HttpClient"/> instance to make GET requests.
        /// </summary>
        private readonly HttpClient _client = new HttpClient();
        
        /// <summary>
        /// The base root url for all API requests.
        /// </summary>
        public const string ApiRoot = "https://nhentai.net";
        
        /// <summary>
        /// The root url for making <see cref="Book"/> requests.
        /// </summary>
        public const string BookRoot = "/api/gallery/";
        
        /// <summary>
        /// The root url for making general <see cref="SearchResult"/> requests.
        /// </summary>
        public const string BookSearchRoot = "/api/galleries/search?query=";
        
        /// <summary>
        /// Downloads and deserializes data into their respect <see cref="T"/> objects. 
        /// </summary>
        /// <param name="url">
        /// The url to make the GET request.
        /// </param>
        /// <typeparam name="T">
        /// The type model the JSON should be deserialized into.
        /// </typeparam>
        /// <returns>
        /// A generic type <see cref="T"/> that contains deserialized JSON data.
        /// </returns>
        public async Task<T> DownloadData<T>(string url)
        {
            var json = await _client.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = false});
        }
        
        /// <summary>
        /// Attempts to find and a parse a <see cref="Book"/> by its Id.
        /// </summary>
        /// <param name="id">
        /// The Id of the <see cref="Book"/> to search for.
        /// </param>
        /// <returns>
        /// A <see cref="Book"/>.
        /// </returns>
        public async Task<Book> SearchBook(int id)
        {
            var url = $"{ApiRoot}{BookRoot}{id}";
            return await DownloadData<Book>(url);
        }

        /// <summary>
        /// Searches for <see cref="Book"/> by the given query.
        /// </summary>
        /// <param name="query">
        /// The search query.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Book"/> that match the search query.
        /// </returns>
        public async Task<SearchResult> SearchQuery(string query)
        {
            var url = $"{ApiRoot}{BookSearchRoot}\"{query}\"";
            return await DownloadData<SearchResult>(url);
        }
        
        /// <summary>
        /// Disposes of the <see cref="HentaiClient"/> client.
        /// </summary>
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}