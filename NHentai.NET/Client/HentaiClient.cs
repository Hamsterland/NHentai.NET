﻿using System;
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
        /// <summary>
        /// The <see cref="HttpClient"/> instance to make GET requests.
        /// </summary>
        private readonly HttpClient _client = new HttpClient();
        
        /// <summary>
        /// The base root url for all API requests.
        /// </summary>
        public const string ApiRoot = "https://nhentai.net";
        
        /// <summary>
        /// The root url for making <see cref="Book"/> requests.
        /// </summary>
        public const string BookRoot = "/api/gallery/";
        
        /// <summary>
        /// The root url for making general <see cref="SearchResult"/> requests.
        /// </summary>
        public const string BookSearchRoot = "/api/galleries/search?query=";

        /// <summary>
        /// The root url for making tag <see cref="SearchResult"/> requests.
        /// </summary>
        public const string TagSearchRoot = "/api/galleries/tagged?tag_id=";

        /// <inheritdoc />
        public async Task<T> DownloadData<T>(string url)
        {
            var json = await _client.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
        
        /// <inheritdoc />
        public async Task<Book> SearchBook(int id)
        {
            var url = $"{ApiRoot}{BookRoot}{id}";
            return await DownloadData<Book>(url);
        }
        
        /// <inheritdoc />
        public async Task<SearchResult> SearchQuery(params string[] query)
        {
            var url = $"{ApiRoot}{BookSearchRoot}{query.ToSearchableString()}";
            return await DownloadData<SearchResult>(url);
        }
        
        /// <inheritdoc />
        public async Task<SearchResult> SearchTag(int id)
        {
            var url = $"{ApiRoot}{TagSearchRoot}{id}";
            return await DownloadData<SearchResult>(url);
        }
 
        /// <inheritdoc cref="IHentaiClient" />
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}