using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using MongoDbGenericRepository.Models;

namespace Venu.Events.API.Domain
{
    [CollectionName("venue")]
    [BsonIgnoreExtraElements]
    public class Venue : IDocument<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public int Version { get; set; }
        public string Name { get; set; }
        public List<Section> Sections { get; set; }

        private Venue(string name)
        {
            Name = name;
            Version = 1;
        }

        public static Venue CreateDraft(
            string name,
            List<Section> sections
        )
        {
            return new Venue(name)
            {
               Sections = sections
            };
        }
    }

    public class Section
    {
        public int Ordinal { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public double Price { get; set; }
    }
}