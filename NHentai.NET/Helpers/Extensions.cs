using System.Collections.Generic;
using System.Text.Json;
using NHentai.NET.Models;

namespace NHentai.NET.Helpers
{
    public static class Extensions
    {
        public static string ToSearchableString(this IEnumerable<string> source)
        {
            return string.Join("+", source);
        }
    }
}