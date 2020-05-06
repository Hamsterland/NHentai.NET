using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHentai.NET.Models;
using NHentai.NET.Models.Books;
using NHentai.NET.Models.Enums;
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
        Task<T> DownloadData<T>(string url);
        
        /// <summary>
        /// Searches for a book.
        /// </summary>
        /// <param name="id">The book Id.</param>
        /// <returns>
        /// A <see cref="Book"/> that matches the given Id. 
        /// </returns>
        Task<Book> SearchBook(int id);
        
        /// <summary>
        /// Gets a <see cref="Book"/> cover image.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// The cover image url.
        /// </returns>
        string GetBookCover(Book book);
        
        
        /// <summary>
        /// Gets a book cover image.
        /// </summary>
        /// <param name="mediaId">The book media Id.</param>
        /// <returns>
        /// The cover image url.
        /// </returns>
        string GetBookCover(string mediaId);
        
        /// <summary>
        /// Gets a <see cref="Book"/> page.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <param name="page">The page number.</param>
        /// <returns>
        /// The page image url.
        /// </returns>
        string GetBookPage(Book book, int page);
        
        /// <summary>
        /// Gets a <see cref="Book"/> page.
        /// </summary>
        /// <param name="id">The book Id.</param>
        /// <param name="page">The page number.</param>
        /// <returns>
        /// The page image url.
        /// </returns>
        Task<string> GetBookPage(int id, int page);
        
        /// <summary>
        /// Gets a <see cref="Book"/> page.
        /// </summary>
        /// <param name="mediaId">The book media Id.</param>
        /// <param name="page">The page number.</param>
        /// <returns>
        /// The page image url.
        /// </returns>
        string GetBookPage(string mediaId, int page);
        
        /// <summary>
        /// Gets all <see cref="Book"/> pages.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of image urls.
        /// </returns>
        IEnumerable<string> GetAllBookPages(Book book);
        
        /// <summary>
        /// Gets all <see cref="Book"/> pages.
        /// </summary>
        /// <param name="id">The book Id.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of image urls.
        /// </returns>
        Task<IEnumerable<string>> GetAllBookPages(int id);
        
        /// <summary>
        /// Searches for matched <see cref="Book"/>s.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>
        /// A <see cref="SearchResult"/> that contains matched <see cref="Book"/>s.
        /// </returns>
        Task<SearchResult> SearchQuery(params string[] query);
        
        /// <summary>
        /// Searches for related <see cref="Book"/>s.
        /// </summary>
        /// <param name="id">The book Id.</param>
        /// <returns>
        /// A <see cref="SearchResult"/> that contains related <see cref="Book"/>s.
        /// </returns>
        Task<SearchResult> SearchRelated(int id);
        
        /// <summary>
        /// Searches for matched <see cref="Book"/>s by tag Id.
        /// </summary>
        /// <param name="id">The tag Id.</param>
        /// <returns>
        /// A <see cref="SearchResult"/> that contains matched <see cref="Book"/>s.
        /// </returns>
        Task<SearchResult> SearchTag(int id);
    }
}