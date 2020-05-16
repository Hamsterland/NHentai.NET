using System;
using System.Linq;
using System.Threading.Tasks;
using NHentai.NET.Models.Enums;
using NUnit.Framework;

namespace NHentai.Net.Test
{
    public class BookTest : BaseTest
    {
        [Test]
        public async Task TestBookResult()
        {
            var result = await HentaiClient.SearchBook(177013);

            Assert.AreEqual(177013, result.Id);
            Assert.AreEqual(987560, result.MediaId);
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
            Assert.IsTrue(result.Books.First().Id == 83932);
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
        public async Task TestExcludeResult()
        {
            var result = await HentaiClient.SearchQuery("yuri", "-fingering");
            Assert.IsTrue(result.Books.Any(x => x.Tags.Any(b => b.Name != "fingering")));
        }
        
        [Test]
        public async Task TestCoverResult()
        {
            var book = await HentaiClient.SearchBook(177013);
            
            var result = book.Images.Cover.Type;
            Assert.AreEqual(result, FileType.Jpg);

            var cover = book.GetCover();
            Assert.AreEqual(cover, "https://t.nhentai.net/galleries/987560/cover.jpg");
        }
        
        [Test]
        public async Task TestSuccessfulBookPage()
        {
            var book = await HentaiClient.SearchBook(177013);
            var result = book.GetPage(15);
            Assert.AreEqual(result, "https://i.nhentai.net/galleries/987560/15.jpg");
        }
        
        [Test]
        public async Task TestUnsuccessfulBookPage()
        {
            try
            {
                var book = await HentaiClient.SearchBook(177013);
                book.GetPage(54000);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }
        
        
        /*
        [Test]
        public async Task TestAllBookPages()
        {
            var book = await HentaiClient.SearchBook(177013);
            var result = book.GetPages();
        }
        */
        

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