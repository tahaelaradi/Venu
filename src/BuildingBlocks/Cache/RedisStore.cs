using System;
using StackExchange.Redis;

namespace Cache
{
    public class RedisStore
    {
        private static string _endpoint { get; set; }
        private static int _retryCount { get; set; }
        private IDatabase _dbInstance { get; set; }

        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            if (String.IsNullOrWhiteSpace(_endpoint)) return null;

            ConfigurationOptions config = new ConfigurationOptions();
            config.EndPoints.Add(_endpoint);
            config.ConnectRetry = _retryCount;
            config.KeepAlive = 10;

            config.AbortOnConnectFail = false;
            config.AllowAdmin = false;

            return ConnectionMultiplexer.Connect(config);
        });

        private static ConnectionMultiplexer Connection => LazyConnection.Value;

        public IDatabase Instance => _dbInstance;

        public RedisStore(string endpoint, int retryCount)
        {
            _endpoint = endpoint;
            _retryCount = retryCount;

            if (Connection != null) _dbInstance = Connection.GetDatabase(0);
        }
    }
}