using System;
using System.Collections.Generic;
using NHentai.NET.Client;
using NHentai.NET.Models.Books;

namespace NHentai.NET.Helpers
{
    /// <summary>
    /// Represents a class of <see cref="Book"/> helper extension methods.
    /// </summary>
    public static class BookExtensions
    {
        /// <summary>
        /// Generates a link for a certain page in a <see cref="Book"/>.
        /// </summary>
        /// <param name="book">The book to generate the page from.</param>
        /// <param name="page">The page number to retrieve.</param>
        /// <returns>
        /// A page link.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown if the specified page number is outside the bounds of the book.
        /// </exception>
        public static string GetPage(this Book book, int page)
        {
            if (page <= 0 || page > book.PagesCount)
            {
                throw new IndexOutOfRangeException("The page number you specified is outside the bounds of this book.");
            }
            
            return $"{HentaiConfig.ImageApiRoot}{string.Format(HentaiConfig.PageSearchRoot, book.MediaId, page)}";
        }

        /// <summary>
        /// Generates links for all pages in a <see cref="Book"/> through iteration.
        /// </summary>
        /// <param name="book">The book to generate pages links from.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of page links.
        /// </returns>
        public static IEnumerable<string> GetPages(this Book book)
        {
            var pages = new List<string>();
            
            for (var i = 1; i < book.PagesCount + 1; i++)
            {
                pages.Add(book.GetPage(i));
            }
            
            return pages;
        }

        /// <summary>
        /// Generates a link for the cover image of <see cref="Book"/>.
        /// </summary>
        /// <param name="book">The book to generate the cover from.</param>
        /// <returns>
        /// A cover link.
        /// </returns>
        public static string GetCover(this Book book)
        {
            return string.Format(HentaiConfig.CoverImageRoot, book.MediaId, book.Images.Cover.Type.ToString().ToLower());
        }
    }
}