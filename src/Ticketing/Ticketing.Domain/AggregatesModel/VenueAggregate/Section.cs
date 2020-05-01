using System;
using Venu.Ticketing.Domain.Events;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.VenueAggregate
{
    public sealed class Section : Entity
    {
        public string Id { get; set; } 
        public string VenueId { get; set; }
        public int Ordinal { get; set;}
        public double Price { get; set;}
        public int Rows { get; set;}
        public int Columns { get; set;}
        
        public Section(string venueId, int ordinal, double price, int rows, int columns)
        {
            Id = Guid.NewGuid().ToString();
            VenueId = venueId;
            Ordinal = ordinal;
            Price = price;
            Rows = rows;
            Columns = columns;

            AddSectionCreatedDomainEvent(venueId, this.Id, ordinal, price, rows, columns);
        }
        
        private void AddSectionCreatedDomainEvent(string venueId, string sectionId, int ordinal, double price, int rows, int columns)
        {
            var sectionCreatedDomainEvent = new SectionCreatedDomainEvent(venueId, sectionId, ordinal, price, rows, columns);
            AddDomainEvent(sectionCreatedDomainEvent);
        }
    }
}