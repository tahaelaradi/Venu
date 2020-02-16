using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using MongoDbGenericRepository.Models;

namespace Venu.Events.Domain
{
    [CollectionName("event")]
    [BsonIgnoreExtraElements]
    public class Event : IDocument<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
        
        private Event(string name)
        {
            Name = name;
            Version = 1;
        }
        
        public static Event CreateDraft(string name)
        {
            return new Event(name);
        }
    }
}