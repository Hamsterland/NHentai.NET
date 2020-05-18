using System;
using System.Threading.Tasks;
using NHentai.NET.Models.Books;
using NHentai.NET.Models.Searches;

namespace NHentai.NET.Client
{
    /// <summary>
    /// The main class for handling API requests.
    /// </summary>
    public interface IHentaiClient : IDisposable
    {
        /// <summary>
        /// Downloads Json from an API request and deserializes the data into a generic object.
        /// </summary>
        /// <param name="url">The API request url</param>
        /// <typeparam name="T">The <see cref="Type"/> to be deserialized into.</typeparam>
        /// <returns>
        /// An object with deserialized API request data.
        /// </returns>
        Task<T> DownloadDataAsync<T>(string url);
        
        /// <summary>
        /// Searches for a <see cref="Book"/> by its Id.
        /// </summary>
        /// <param name="id">The book Id.</param>
        /// <returns>
        /// A <see cref="Book"/> that matches the given Id. 
        /// </returns>
        Task<Book> SearchBookAsync(int id);

        /// <summary>
        /// Searches for <see cref="Book"/>s that match the given query.
        /// </summary>
        /// <param name="page">The result page number.</param>
        /// <param name="sort">The result sort filter.</param>
        /// <param name="query">The search query.</param>
        /// <returns>
        /// A <see cref="SearchResult"/> that contains matching <see cref="Book"/>s.
        /// </returns>
        Task<SearchResult> SearchQueryAsync(int page, Sort sort, params string[] query);
        
        /// <summary>
        /// Retrieves recommendations for a given <see cref="Book"/>.
        /// </summary>
        /// <param name="id">The book Id.</param>
        /// <returns>
        /// A <see cref="SearchResult"/> that contains related <see cref="Book"/>s.
        /// </returns>
        Task<SearchResult> SearchRelatedAsync(int id);

        /// <summary>
        /// Searches for <see cref="Book"/>s that contain the given tag by its Id. 
        /// </summary>
        /// <param name="id">The tag Id.</param>
        /// <param name="page">The result page number.</param>
        /// <param name="sort">The result sort filter.</param>
        /// <returns>
        /// A <see cref="SearchResult"/> that contains matched <see cref="Book"/>s.
        /// </returns>
        Task<SearchResult> SearchTagAsync(int id, int page, Sort sort);

        /// <summary>
        /// Retrieves the current <see cref="Book"/>s on the website home page.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<SearchResult> SearchHomePageAsync(int page);
    }
}