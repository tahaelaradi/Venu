using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Venu.Ticketing.Domain.Events;
using Venu.Ticketing.Domain.Exceptions;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.EventAggregate
{
    [Table("VenueSection")]
    public class VenueSection : Entity
    {
        private int _ordinal;
        private double _price;
        private int _rows;
        private int _columns;

        [Key]
        [Column("VenueSectionId")]
        public string Id { get; set; }
        public string VenueId { get; set; }

        protected VenueSection() { }
        
        public VenueSection(string venueId, int ordinal, double price, int rows, int columns)
        {
            Id = Guid.NewGuid().ToString();
            VenueId = venueId;
            _ordinal = ordinal;
            _price = price;
            _rows = rows;
            _columns = columns;

            this.AddVenueSectionCreatedDomainEvent(venueId, ordinal, price, rows, columns);
        }
        
        public int GetOrdinal() => _ordinal;

        public double GetPrice() => _price;

        public void SetNewOrdinal(int ordinal)
        {
            if (ordinal < 0) throw new TicketingDomainException("Ordinal is not valid");
            _ordinal = ordinal;
        }

        public void SetNewPrice(double price)
        {
            if (price < 0) throw new TicketingDomainException("Price is not valid");
            _price = price;
        }
        
        private void AddVenueSectionCreatedDomainEvent(string venueId, int ordinal, double price, int rows, int columns)
        {
            var orderStartedDomainEvent = new VenueSectionCreatedDomainEvent(this, venueId, ordinal, price, rows, columns);
            AddDomainEvent(orderStartedDomainEvent);
        }
    }
}