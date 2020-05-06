using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NHentai.NET.Client;

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
    }
}