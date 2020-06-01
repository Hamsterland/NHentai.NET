using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NHentai.Net.Test
{
    // TODO: Actually create some tests.
    [TestFixture]
    public class BookTest : BaseTest
    {
        [Test]
        public async Task GetPages_EnsureLinksAreCorrect()
        {
            var book = await HentaiClient.SearchBookAsync(125639);
            var actual = book.GetPages().ToList();
            
            var expected = new List<string>
            {
                "https://i.nhentai.net/galleries/779150/1.jpg",
                "https://i.nhentai.net/galleries/779150/2.png",
                "https://i.nhentai.net/galleries/779150/3.jpg",
                "https://i.nhentai.net/galleries/779150/4.jpg",
                "https://i.nhentai.net/galleries/779150/5.jpg",
                "https://i.nhentai.net/galleries/779150/6.jpg",
                "https://i.nhentai.net/galleries/779150/7.jpg",
                "https://i.nhentai.net/galleries/779150/8.jpg",
                "https://i.nhentai.net/galleries/779150/9.jpg",
                "https://i.nhentai.net/galleries/779150/10.jpg",
                "https://i.nhentai.net/galleries/779150/11.jpg",
                "https://i.nhentai.net/galleries/779150/12.jpg",
                "https://i.nhentai.net/galleries/779150/13.jpg",
                "https://i.nhentai.net/galleries/779150/14.jpg",
                "https://i.nhentai.net/galleries/779150/15.jpg",
                "https://i.nhentai.net/galleries/779150/16.jpg",
                "https://i.nhentai.net/galleries/779150/17.jpg",
                "https://i.nhentai.net/galleries/779150/18.jpg",
                "https://i.nhentai.net/galleries/779150/19.png",
                "https://i.nhentai.net/galleries/779150/20.jpg"
            };

            for (var i = 0; i < book.PagesCount - 1; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }
    }
}