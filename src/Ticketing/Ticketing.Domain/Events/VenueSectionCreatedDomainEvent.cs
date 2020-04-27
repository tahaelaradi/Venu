using MediatR;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;

namespace Venu.Ticketing.Domain.Events
{
    public class VenueSectionCreatedDomainEvent : INotification
    {
        public string VenueId { get; }
        public string VenueSectionId { get; }
        public int Ordinal { get; }
        public double Price { get; }
        public int Rows { get; }
        public int Columns { get; }
        
        public VenueSectionCreatedDomainEvent(VenueSection venueSection, string venueId, int ordinal, double price, int rows, int columns)
        {
            VenueId = venueId;
            VenueSectionId = venueSection.Id;
            Ordinal = ordinal;
            Price = price;
            Rows = rows;
            Columns = columns;
        }
    }
}