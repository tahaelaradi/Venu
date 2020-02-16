using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbGenericRepository;
using MongoDbGenericRepository.Models;
using Venu.Events.Common;
using Venu.Events.Domain;

namespace Venu.Events.DataAccess
{
    public class Repository : BaseMongoRepository<string>, IRepository, IMongoAccessor
    {
        public Repository(IOptions<GlobalConfiguration> globalConfiguration): base(globalConfiguration.Value.ConnectionString, globalConfiguration.Value.DatabaseName)
        {
        }

        public IMongoDbContext DbContext => MongoDbContext;

        public string DbName => DatabaseName;

        public IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : IDocument<string>
        {
            return GetCollection<TDocument>(null);
        }
    }
}