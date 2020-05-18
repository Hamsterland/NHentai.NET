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
        public async Task<T> DownloadDataAsync<T>(string url)
        {
            var json = await _client.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(json);
        }
 
        /// <inheritdoc />
        public async Task<Book> SearchBookAsync(int id)
        {
            var url = $"{HentaiConfig.ApiRoot}{HentaiConfig.BookRoot}{id}";
            return await DownloadDataAsync<Book>(url);
        }
        
        
        /// <inheritdoc />
        public async Task<SearchResult> SearchQueryAsync(int page, Sort sort, params string[] query)
        {
            var url = $"{HentaiConfig.ApiRoot}{string.Format(HentaiConfig.BookSearchRoot, query.ToSearchableString(), page, sort.ToSearchableSort())}";
            return await DownloadDataAsync<SearchResult>(url);
        }
        
        /// <inheritdoc />
        public async Task<SearchResult> SearchRelatedAsync(int id)
        {
            var url = $"{HentaiConfig.ApiRoot}{string.Format(HentaiConfig.RelatedSearchRoot, id)}";
            return await DownloadDataAsync<SearchResult>(url);
        }

        /// <inheritdoc />
        public async Task<SearchResult> SearchTagAsync(int id, int page, Sort sort)
        {
            var url = $"{HentaiConfig.ApiRoot}{string.Format(HentaiConfig.TagSearchRoot, id, page, sort.ToSearchableSort())}";
            return await DownloadDataAsync<SearchResult>(url);
        }

        public async Task<SearchResult> SearchHomePageAsync(int page)
        {
            var url = $"{HentaiConfig.ApiRoot}{string.Format(HentaiConfig.HomePageRoot, page)}";
            return await DownloadDataAsync<SearchResult>(url);
        }

        /// <summary>
        /// Disposes of an unused <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}