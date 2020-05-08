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
            return JsonSerializer.Deserialize<T>(json);
        }
 
        /// <inheritdoc />
        public async Task<Book> SearchBook(int id)
        {
            var url = $"{HentaiConfig.ApiRoot}{HentaiConfig.BookRoot}{id}";
            return await DownloadData<Book>(url);
        }
        
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

        /// <summary>
        /// Disposes of an unused <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}