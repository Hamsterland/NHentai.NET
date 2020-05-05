using System;
using System.Linq;
using System.Threading.Tasks;
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
            Assert.AreEqual("[ShindoLA] METAMORPHOSIS (Complete) [English]", result.Titles.English);
            Assert.AreEqual("METAMORPHOSIS", result.Titles.Pretty);
            Assert.AreEqual(31, result.Tags.Count);
            Assert.AreEqual(225, result.PagesCount);
            Assert.AreEqual(24684, result.FavoritesCount);
        }

        [Test]
        public async Task TestRelatedResult()
        {
            var result = await HentaiClient.SearchRelated(177013);
            Assert.IsTrue(result.Books.First().JsonId.GetString() == "83932");
        }

        [Test]
        public async Task TestSuccessfulBookPage()
        {
            var book = await HentaiClient.SearchBook(177013);
            var result = HentaiClient.GetBookPage(book, 15);
            
            Assert.AreEqual(result, "https://i.nhentai.net/galleries/987560/15.jpg");
        }

        [Test]
        public async Task TestUnsuccessfulBookPage()
        {
            try
            {
                var book = await HentaiClient.SearchBook(177013);
                var result = HentaiClient.GetBookPage(book, 5000);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task TestBookPageById()
        {
            var result = await HentaiClient.GetBookPage(177013, 15);
            Assert.AreEqual(result, "https://i.nhentai.net/galleries/987560/15.jpg");
        }
        
        [Test]
        public void TestBookPageByMediaId()
        {
            var result = HentaiClient.GetBookPage("987560", 15);
            Assert.AreEqual(result, "https://i.nhentai.net/galleries/987560/15.jpg");
        }

        [Test]
        public async Task TestAllBookPages()
        {
            var book = await HentaiClient.SearchBook(177013);
            var result = HentaiClient.GetAllBookPages(book);
            
            // Looking for a proper way to test this. Need to extract a list of page URLs. 
            Assert.IsTrue(true);
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

        [Test]
        public async Task TestCoverResult()
        {
            var book = await HentaiClient.SearchBook(177013);
            var cover = HentaiClient.GetBookCover(book);
            
            Assert.AreEqual(cover, "https://t.nhentai.net/galleries/987560/cover.jpg");
        }

        [Test]
        public async Task TestTagResult()
        {
            var result = await HentaiClient.SearchTag(31247);

            foreach (var book in result.Books)
            {
                Assert.IsTrue(book.Tags.Select(x => x.Id).Contains(31247));
            }
        }
    }
}