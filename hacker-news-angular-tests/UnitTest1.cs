using hacker_news_angular_v1.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace hacker_news_angular_v1_tests
{
    [TestClass]
    public class HackerNewsUnitTest
    {
        private readonly ILogger<HackerNewsController> _logger;

        public HackerNewsUnitTest()
        {

        }

        public HackerNewsUnitTest(ILogger<HackerNewsController> logger)
        {
            _logger = logger;
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            HackerNewsController hackerNewsController = new HackerNewsController(_logger);
            var articleIds = await hackerNewsController.Get();

            Assert.IsNotNull(articleIds);

            var firstId = articleIds.First();

            Assert.IsInstanceOfType(firstId, typeof(int));

            var articleDetail = await hackerNewsController.Get(firstId.ToString());

            Assert.IsNotNull(articleDetail);
        }
    }
}
