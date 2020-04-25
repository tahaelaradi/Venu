using System;

namespace Venu.Events.API.ViewModel
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; private set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public string TicketsUrl { get; set; }
        public string PrimaryOrganizerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedOn { get; set; }
        public string VenueId { get; set; }
        public string Category { get; set; }
        public string[] Tags { get; set; }
        public string Language { get; set; }
        public bool IsSoldOut { get; set; }
        public bool IsFree { get; set; }
        public Address Address { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
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
}