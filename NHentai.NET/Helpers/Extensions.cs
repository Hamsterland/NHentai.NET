using System.Collections.Generic;
using System.Text.Json;
using NHentai.NET.Models;

namespace NHentai.NET.Helpers
{
    /// <summary>
    /// Represents a class of static helper extensions methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> of <see cref="string"/> into a queryable <see cref="string"/>.
        /// </summary>
        /// <param name="source">The list of strings to be formatted.</param>
        /// <returns>
        /// A queryable <see cref="string"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// var searches = new [] { "sole male", "futanari", "blowjob" };
        /// var queryable = searches.ToSearchableString();
        /// </code>
        /// <returns>
        /// Output: "sole male+futanari+blowjob"
        /// </returns>
        /// </example>
        public static string ToSearchableString(this IEnumerable<string> source)
        {
            return string.Join("+", source);
        }
    }
}