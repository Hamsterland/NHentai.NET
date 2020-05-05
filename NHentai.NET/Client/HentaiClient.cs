using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NHentai.NET.Models;
using System.Text.Json;
using NHentai.NET.Helpers;
using NHentai.NET.Models.Searches;

namespace NHentai.NET.Client
{
    public class HentaiClient : IHentaiClient, IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        
        public const string ApiRoot = "https://nhentai.net";

        public const string ImageApiRoot = "https://i.nhentai.net";

        public const string CoverImageRoot = "https://t.nhentai.net/galleries/{0}/cover.{1}";
        
        public const string BookRoot = "/api/gallery/";
        
        public const string RelatedSearchRoot = "/api/gallery/{0}/related";
        
        public const string BookSearchRoot = "/api/galleries/search?query=";
        
        public const string TagSearchRoot = "/api/galleries/tagged?tag_id=";

        public const string PageSearchRoot = "/galleries/{0}/{1}.jpg";
        
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

        public string GetBookCover(Book book)
        {
            return string.Format(CoverImageRoot, book.MediaId, book.Images.Cover.Type.ToString().ToLower());
        }
        
        public string GetBookCover(string mediaId)
        {
            try
            {
                return string.Format(CoverImageRoot, mediaId, "jpg");
            }
            catch (Exception)
            {
                return string.Format(CoverImageRoot, mediaId, "png");
            }
        }

        public string GetBookPage(Book book, int page)
        {
            if (page <= 0 || page > book.PagesCount)
            {
                throw new IndexOutOfRangeException("The page number you specified is outside the bounds of this book.");
            }
            
            return $"{ImageApiRoot}{string.Format(PageSearchRoot, book.MediaId, page)}";
        }

        public async Task<string> GetBookPage(int id, int page)
        {
            var book = await SearchBook(id);
            return $"{ImageApiRoot}{string.Format(PageSearchRoot, book.MediaId, page)}";
        }

        public string GetBookPage(string mediaId, int page)
        {
            return $"{ImageApiRoot}{string.Format(PageSearchRoot, mediaId, page)}";
        }

        public IEnumerable<string> GetAllBookPages(Book book)
        {
            var pages = new List<string>();

            for (var i = 1; i < book.PagesCount + 1; i++)
            {
                pages.Add(GetBookPage(book, i));
            }

            return pages;
        }
        
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