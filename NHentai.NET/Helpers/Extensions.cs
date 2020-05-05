using System.Collections.Generic;

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