using System.Collections.Generic;
using System.Threading.Tasks;
using NHentai.NET.Models;
using NHentai.NET.Models.Searches;

namespace NHentai.NET.Client
{
    public interface IHentaiClient
    {
        Task<T> DownloadData<T>(string url);
        Task<Book> SearchBook(int id);
        string GetBookPage(Book book, int page);
        Task<string> GetBookPage(int id, int page);
        string GetBookPage(string mediaId, int page);
        IEnumerable<string> GetAllBookPages(Book book);
        Task<IEnumerable<string>> GetAllBookPages(int id);
        Task<SearchResult> SearchRelated(int id);
        Task<SearchResult> SearchQuery(params string[] query);
        Task<SearchResult> SearchTag(int id);
        void Dispose();
    }
}