using System;
using System.ComponentModel.DataAnnotations.Schema;
using Venu.Ticketing.Domain.Exceptions;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.EventAggregate
{
    [Table("VenueSection")]
    public class VenueSection : Entity
    {
        private int _ordinal;
        private double _price;

        protected VenueSection() { }
        
        public VenueSection(string venueId, int ordinal, double price)
        {
            Console.WriteLine($"creating...{venueId},{ordinal},{price}");
            VenueId = venueId;
            
            _ordinal = ordinal;
            _price = price;
        }

        public string VenueId { get; set; }
        
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
    }
}