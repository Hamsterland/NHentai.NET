using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHentai.NET.Models;
using NHentai.NET.Models.Searches;

namespace NHentai.NET.Client
{
    /// <summary>
    /// Represents the main client that handles all requests.
    /// </summary>
    public interface IHentaiClient
    {
        /// <summary>
        /// Downloads and deserializes data into their respect <see cref="T"/> objects. 
        /// </summary>
        /// <param name="url">The url to make the GET request to.</param>
        /// <typeparam name="T">The type model the Json should be deserialized into.</typeparam>
        /// <returns>
        /// A generic type <see cref="T"/> that contains deserialized Json data.
        /// </returns>
        Task<T> DownloadData<T>(string url);

        /// <summary>
        /// Attempts to find and a parse a <see cref="Book"/> by its Json Id.
        /// </summary>
        /// <param name="id">The Json Id of the <see cref="Book"/> to search for.</param>
        /// <returns>
        /// A <see cref="Book"/> that contains the given <see cref="id"/>.
        /// </returns>
        Task<Book> SearchBook(int id);

        /// <summary>
        /// Searches for <see cref="Book"/> by the given <see cref="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Book"/> that contains the given <see cref="query"/>.
        /// </returns>
        Task<SearchResult> SearchQuery(params string[] query);

        /// <summary>
        /// Searches for <see cref="Book"/> by the given <see cref="Tag"/> Id.
        /// </summary>
        /// <param name="id">The of the <see cref="Tag"/> to search for.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Book"/> that contain the given <see cref="Tag"/>.
        /// </returns>
        Task<SearchResult> SearchTag(int id);
        
        /// <summary>
        /// Disposes of the <see cref="IHentaiClient"/> instance.
        /// </summary>
        public void Dispose();
    }
}