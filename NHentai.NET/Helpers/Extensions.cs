using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NHentai.NET.Client;
using NHentai.NET.Models.Searches;

namespace NHentai.NET.Helpers
{
    /// <summary>
    /// Represents a class of general extension helper methods.
    /// </summary>
    /// <remarks>
    /// Intended for miscellaneous use.
    /// </remarks>
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
            return services
                .AddScoped<IHentaiClient, HentaiClient>()
                .AddScoped<Random>();
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
        /// Turns a <see cref="Sort"/> enum to an API-friendly searchable <see cref="string"/>.
        /// </summary>
        /// <param name="sort">The chosen sort filter.</param>
        /// <returns>
        /// An API-searchable <see cref="string"/>.
        /// </returns>
        public static string ToSearchableSort(this Sort sort)
        {
            return sort.ToString().ToLower();
        }
    }
}