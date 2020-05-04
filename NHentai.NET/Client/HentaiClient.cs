using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NHentai.NET.Models;
using System.Text.Json;
using NHentai.NET.Helpers;
using NHentai.NET.Models.Searches;

namespace NHentai.NET.Client
{
    /// <summary>
    /// Implements <see cref="IHentaiClient"/>.
    /// </summary>
    public class HentaiClient : IHentaiClient, IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        
        public const string ApiRoot = "https://nhentai.net";
        
        public const string BookRoot = "/api/gallery/";
        
        public const string RelatedSearchRoot = "/api/gallery/{0}/related";
        
        public const string BookSearchRoot = "/api/galleries/search?query=";
        
        public const string TagSearchRoot = "/api/galleries/tagged?tag_id=";

        public const string PageSearchRoot = "galleries/{0}/{1}.jpg";
        
        public async Task<T> DownloadData<T>(string url)
        {
            var json = await _client.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
 
        public async Task<Book> SearchBook(int id)
        {
            var url = $"{ApiRoot}{BookRoot}{id}";
            return await DownloadData<Book>(url);
        }

        public async Task<SearchResult> SearchRelated(int id)
        {
            var url = $"{ApiRoot}{string.Format(RelatedSearchRoot, id)}";
            return await DownloadData<SearchResult>(url);
        }
        
        public async Task<SearchResult> SearchQuery(params string[] query)
        {
            var url = $"{ApiRoot}{BookSearchRoot}{query.ToSearchableString()}";
            return await DownloadData<SearchResult>(url);
        }
        
        public async Task<SearchResult> SearchTag(int id)
        {
            var url = $"{ApiRoot}{TagSearchRoot}{id}";
            return await DownloadData<SearchResult>(url);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}