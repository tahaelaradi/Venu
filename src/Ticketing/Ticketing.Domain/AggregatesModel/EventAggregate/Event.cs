using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.EventAggregate
{
    [Table("Event")]
    public class Event : Entity, IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        // Using a private collection field for DDD Aggregate's encapsulation
        // so can only be added through the method AddVenueSection()
        private readonly List<VenueSection> _venueSections;
        public IReadOnlyCollection<VenueSection> VenueSections => _venueSections;

        public Event(string id, string name)
        {
            Id = id;
            Name = name;
            IsActive = false;
            CreatedOn = DateTime.Now;
            _venueSections = new List<VenueSection>();
        }
        
        public void AddVenueSection(string venueId, int ordinal, double price, int rows, int columns)
        {
            var existingVenueSectionForEvent = _venueSections.SingleOrDefault(s => s.VenueId == venueId);

            if (existingVenueSectionForEvent != null)
            {
                existingVenueSectionForEvent.SetNewOrdinal(ordinal);
                existingVenueSectionForEvent.SetNewPrice(price);
            }
            else
            {
                var venueSection = new VenueSection(venueId, ordinal, price, rows, columns);
                _venueSections.Add(venueSection);
            }
        }
    }
}