using Cache;
using NUnit.Framework;
using Venu.BuildingBlocks.Shared.Types;

namespace Tests
{
    public class CacheServiceTests
    {
        private CacheService _cacheService;
        
        [SetUp]
        public void Setup()
        {
            var opts = new RedisOptions
            {
                Host = "127.0.0.1:6379",
                RetryCount = 5
            };
            
            _cacheService = new CacheService(opts);
        }

        [Test]
        public void Test_Publishing_Message()
        {
            var msg = new
            {
                Test = "Value"
            };
            
            _cacheService.PublishAsync(msg, "event_1");
        }
    }
}