using System;
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
        
        Task<SearchResult> SearchRelated(int id);
        
        Task<SearchResult> SearchQuery(params string[] query);
        
        Task<SearchResult> SearchTag(int id);
        
        public void Dispose();
    }
}