using NHentai.NET.Client;
using NUnit.Framework;

namespace NHentai.Net.Test
{
    public class BaseTest
    {
        protected IHentaiClient HentaiClient { get; set; }

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