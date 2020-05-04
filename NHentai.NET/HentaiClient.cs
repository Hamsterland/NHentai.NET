using System;
using System.Net.Http;
using System.Threading.Tasks;
using NHentai.NET.Models;
using System.Text.Json;
using NHentai.NET.Models.Searches;

namespace NHentai.NET
{
    public class HentaiClient : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        
        public const string ApiRoot = "https://nhentai.net";
        public const string BookRoot = "/api/gallery/";
        public const string BookSearchRoot = "/api/galleries/search?query=";
        
        public async Task<T> DownloadData<T>(string url)
        {
            var json = await _client.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = false});
        }
        
        public async Task<Book> SearchBook(int id)
        {
            var url = $"{ApiRoot}{BookRoot}{id}";
            return await DownloadData<Book>(url);
        }

        public async Task<SearchResult> SearchQuery(string query)
        {
            var url = $"{ApiRoot}{BookSearchRoot}\"{query}\"";
            return await DownloadData<SearchResult>(url);
        }
        
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}