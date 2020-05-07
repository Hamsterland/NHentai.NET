using System.Collections.Generic;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using NHentai.NET.Client;
using NHentai.NET.Models.Books;

namespace NHentai.NET.Helpers
{
    /// <summary>
    /// Represents a class of static extension helper methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds <see cref="IHentaiClient"/> and <see cref="HentaiClient"/> to a <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        /// Configures <see cref="IHentaiClient"/> as a dependency.
        /// </returns>
        public static IServiceCollection AddHentaiClient(this IServiceCollection services)
        {
            return services.AddScoped<IHentaiClient, HentaiClient>();
        }
        
        /// <summary>
        /// Joins an <see cref="IEnumerable{T}"/> <see cref="string"/> list of queries into an API-friendly
        /// searchable <see cref="string"/>.
        /// </summary>
        /// <param name="source">The list of queries.</param>
        /// <returns>
        /// An API-searchable <see cref="string"/>.
        /// </returns>
        public static string ToSearchableString(this IEnumerable<string> source)
        {
            return string.Join("+", source);
        }

        /// <summary>
        /// Generates links for all images in a <see cref="Book"/> through iteration.
        /// </summary>
        /// <param name="book">The book to generate pages links from.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of page links.
        /// </returns>
        public static IEnumerable<string> GetPages(this Book book)
        {
            var client = new HentaiClient();
            var pages = new List<string>();
            
            for (var i = 1; i < book.PagesCount + 1; i++)
            {
                pages.Add(client.GetBookPage(book, i));
            }
            
            return pages;
        }
    }
}