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
            
            Assert.AreEqual(177013, result.Id);
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
            var result = await HentaiClient.SearchQuery("sole male");

            foreach (var book in result.Books)
            {
                Assert.IsTrue(book.Tags.Select(x => x.Name).Contains("sole male"));
            }
        }
    }
}