using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NHentai.NET.Helpers;
using NUnit.Framework;

namespace NHentai.Net.Test
{
    public class BookTest : BaseTest
    {
        [Test]
        public async Task TestBookResult()
        {
            var result = await HentaiClient.SearchBook(177013);

            Assert.AreEqual(177013, result.JsonId.GetInt32());
            Assert.AreEqual("987560", result.MediaId);
            Assert.AreEqual("[ShindoLA] METAMORPHOSIS (Complete) [English]", result.Title.English);
            Assert.AreEqual("METAMORPHOSIS", result.Title.Pretty);
            Assert.AreEqual(31, result.Tags.Count);
            Assert.AreEqual(225, result.PagesCount);
            Assert.AreEqual(24684, result.FavoritesCount);
        }

        [Test]
        public async Task TestBooksResult()
        {
            var result = await HentaiClient.SearchQuery("yuri", "females only");

            foreach (var book in result.Books)
            {
                Assert.IsTrue(book.Tags.Select(x => x.Name).Contains("yuri"));
                Assert.IsTrue(book.Tags.Select(x => x.Name).Contains("females only"));
            }
        }
    }
}