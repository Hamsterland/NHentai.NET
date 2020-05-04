using NHentai.NET;
using NUnit.Framework;

namespace NHentai.Net.Test
{
    public class BaseTest
    {
        protected HentaiClient HentaiClient { get; set; }

        [SetUp]
        public void Setup()
        {
            HentaiClient = new TestHentaiClient();
        }

        [TearDown]
        public void CleanUp()
        {
            HentaiClient.Dispose();
        }
    }

    public class TestHentaiClient : HentaiClient
    {
    }
}