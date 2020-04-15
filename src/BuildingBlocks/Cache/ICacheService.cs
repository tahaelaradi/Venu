using System;
using System.Threading.Tasks;

namespace Cache
{
    public interface ICacheService
    {
        string StringGet(string key);
        void StringSet(string key, string value, TimeSpan? expirationSpan = null);
        void Remove(string key);
        Task PublishAsync<TMessage>(TMessage msg, string channel);
        Task SubscribeAsync(string msg, string channel);
    }
}