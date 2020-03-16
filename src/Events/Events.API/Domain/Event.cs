using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using MongoDbGenericRepository.Models;

namespace Venu.Events.API.Domain
{
    [CollectionName("event")]
    [BsonIgnoreExtraElements]
    public class Event : IDocument<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public int Version { get; set; }
        public string Name { get; set; }
        public Status Status { get; private set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public string TicketsUrl { get; set; }
        public string PrimaryOrganizerId { get; set; }
        public string Summary { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public DateTime PublishedDate { get; set; }

        public string VenueId { get; set; }
        public string[] Tags { get; set; }

        public bool HasVenue { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsSoldOut { get; set; }
        public bool IsFree { get; set; }

        public Address Address { get; set; }
        public Image Image { get; set; }

        public int Likes { get; set; }
        public int Shares { get; set; }

        private Event(string name)
        {
            Name = name;
            Version = 1;
        }

        public static Event CreateDraft(
            string name,
            string type,
            string category,
            string url,
            string primaryOrganizerId,
            string summary,
            DateTime startDate,
            DateTime endDate,
            string venueId,
            string[] tags,
            bool hasVenue,
            bool isFree,
            Address address,
            Image image
        )
        {
            return new Event(name)
            {
                Status = Status.DRAFT,
                Type = type,
                Category = category,
                Url = url,
                TicketsUrl = Guid.NewGuid().ToString(),
                PrimaryOrganizerId = primaryOrganizerId,
                Summary = summary,
                StartDate = startDate,
                EndDate = endDate,
                CreatedOn = DateTime.Now,
                VenueId = venueId,
                Tags = tags,
                HasVenue = hasVenue,
                IsFree = isFree,
                Address = address,
                Image = image
            };
        }
    }

    public enum Status
    {
        DRAFT,
        SUBMITTED,
        APPROVED,
        REJECTED,
        PUBLISHED,
        CANCELED,
        CLOSED
    }

    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string AddressDisplayName { get; set; }
    }

    public class Image
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }
}