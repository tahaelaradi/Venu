using MediatR;

namespace Venu.Ticketing.Domain.Events
{
    public class SectionCreatedDomainEvent : INotification
    {
        public string VenueId { get; set; }
        public string SectionId { get; set; }
        public int Ordinal { get; set;}
        public double Price { get; set;}
        public int Rows { get; set;}
        public int Columns { get; set;}
        
        public SectionCreatedDomainEvent(string venueId, string sectionId, int ordinal, double price, int rows, int columns)
        {
            VenueId = venueId;
            SectionId = sectionId;
            Ordinal = ordinal;
            Price = price;
            Rows = rows;
            Columns = columns;
        }
    }
}