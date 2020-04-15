using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using Venu.BuildingBlocks.Shared.Types;

namespace Cache
{
    public class CacheService : ICacheService
    {
        private RedisStore _cache;

        public CacheService(RedisOptions options)
        {
            _cache = new RedisStore(options.Host, options.RetryCount);
        }

        public string StringGet(string key)
        {
            return _cache.Instance.StringGet(key);
        }

        public void StringSet(string key, string value, TimeSpan? expirationSpan = null)
        {
            _cache.Instance.StringSet(key, value, expirationSpan);
        }

        public void Remove(string key)
        {
            _cache.Instance.KeyDelete(key);
        }
        
        public async Task PublishAsync<TMessage>(TMessage msg, string channel)
        {
            var pub = _cache.Instance.Multiplexer.GetSubscriber();
            await pub.PublishAsync(channel, JsonConvert.SerializeObject(msg));
        }

        public async Task SubscribeAsync(string msg, string channel)
        {
            var sub = _cache.Instance.Multiplexer.GetSubscriber();
            await sub.SubscribeAsync(channel, (_, message) =>
            {
                Log.Information($"{channel}: Subscribe the message with the content is {JsonConvert.SerializeObject(message)}.");
            });
        }
    }
}