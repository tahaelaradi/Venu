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
        public Layout Layout { get; set; }

        private Venue(string name)
        {
            Name = name;
            Version = 1;
        }

        public static Venue CreateDraft(
            string name/*,
            Layout layout
            */
        )
        {
            return new Venue(name)
            {
                // TODO: Add converters (maybe use automapper?)
                Layout = new Layout()
                {
                }
            };
        }
    }

    public class Layout
    {
        public Section[] Sections { get; set; }
        public float Price { get; set; }
    }

    public class Section
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}