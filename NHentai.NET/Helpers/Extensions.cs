using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NHentai.NET.Client;

namespace NHentai.NET.Helpers
{
    public static class Extensions
    {
        public static IServiceCollection AddHentaiClient(this IServiceCollection services)
        {
            return services.AddScoped<IHentaiClient, HentaiClient>();
        }
        
        public static string ToSearchableString(this IEnumerable<string> source)
        {
            return string.Join("+", source);
        }
    }
}