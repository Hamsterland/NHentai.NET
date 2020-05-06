using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using NHentai.NET.Helpers;
using NHentai.NET.Models.Books;
using NHentai.NET.Models.Searches;

namespace NHentai.NET.Client
{
    /// <summary>
    /// Implements <see cref="IHentaiClient"/>.
    /// </summary>
    public class HentaiClient : IHentaiClient
    {
        /// <summary>
        /// The <see cref="HttpClient"/> instance used to make GET requests.
        /// </summary>
        private readonly HttpClient _client = new HttpClient();

        /// <inheritdoc />
        public async Task<T> DownloadData<T>(string url)
        {
            var json = await _client.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
 
        /// <inheritdoc />
        public async Task<Book> SearchBook(int id)
        {
            var url = $"{HentaiConfig.ApiRoot}{HentaiConfig.BookRoot}{id}";
            return await DownloadData<Book>(url);
        }
        
        #region Cover

        /// <inheritdoc />
        public string GetBookCover(Book book)
        {
            return string.Format(HentaiConfig.CoverImageRoot, book.MediaId, book.Images.Cover.Type.ToString().ToLower());
        }
        
        /// <inheritdoc />
        public string GetBookCover(string mediaId)
        {
            try
            {
                return string.Format(HentaiConfig.CoverImageRoot, mediaId, "jpg");
            }
            catch (Exception)
            {
                return string.Format(HentaiConfig.CoverImageRoot, mediaId, "png");
            }
        }

        #endregion
        
        #region Page

        /// <inheritdoc />
        public string GetBookPage(Book book, int page)
        {
            if (page <= 0 || page > book.PagesCount)
            {
                throw new IndexOutOfRangeException("The page number you specified is outside the bounds of this book.");
            }
            
            return $"{HentaiConfig.ImageApiRoot}{string.Format(HentaiConfig.PageSearchRoot, book.MediaId, page)}";
        }

        /// <inheritdoc />
        public async Task<string> GetBookPage(int id, int page)
        {
            var book = await SearchBook(id);
            return $"{HentaiConfig.ImageApiRoot}{string.Format(HentaiConfig.PageSearchRoot, book.MediaId, page)}";
        }

        /// <inheritdoc />
        public string GetBookPage(string mediaId, int page)
        {
            return $"{HentaiConfig.ImageApiRoot}{string.Format(HentaiConfig.PageSearchRoot, mediaId, page)}";
        }
        
        #endregion
        
        #region AllPages

        /// <inheritdoc />
        public IEnumerable<string> GetAllBookPages(Book book)
        {
            var pages = new List<string>();

            for (var i = 1; i < book.PagesCount + 1; i++)
            {
                pages.Add(GetBookPage(book, i));
            }

            return pages;
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<string>> GetAllBookPages(int id)
        {
            var book = await SearchBook(id);
            var pages = new List<string>();

            for (var i = 1; i < book.PagesCount + 1; i++)
            {
                pages.Add(GetBookPage(book, i));
            }

            return pages;
        }
        
        #endregion
        
        #region Searches

        /// <inheritdoc />
        public async Task<SearchResult> SearchQuery(params string[] query)
        {
            var url = $"{HentaiConfig.ApiRoot}{HentaiConfig.BookSearchRoot}{query.ToSearchableString()}";
            return await DownloadData<SearchResult>(url);
        }
        
        /// <inheritdoc />
        public async Task<SearchResult> SearchRelated(int id)
        {
            var url = $"{HentaiConfig.ApiRoot}{string.Format(HentaiConfig.RelatedSearchRoot, id)}";
            return await DownloadData<SearchResult>(url);
        }

        /// <inheritdoc />
        public async Task<SearchResult> SearchTag(int id)
        {
            var url = $"{HentaiConfig.ApiRoot}{HentaiConfig.TagSearchRoot}{id}";
            return await DownloadData<SearchResult>(url);
        }
        
        #endregion

        /// <summary>
        /// Disposes of an unused <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}