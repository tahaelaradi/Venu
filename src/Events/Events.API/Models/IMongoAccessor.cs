using MongoDB.Driver;
using MongoDbGenericRepository;
using MongoDbGenericRepository.Models;

namespace Venu.Events.API.Models
{
    public interface IMongoAccessor
    {
        string DbName { get; }
        
        IMongoDbContext DbContext { get; }
        
        IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : IDocument<string>;
    }
}