using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.VenueAggregate
{
    [Table("venues")]
    public class Venue : Entity, IAggregateRoot
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        
        private readonly List<Section> _sections;
        public IReadOnlyCollection<Section> Sections => _sections;
        
        public Venue(string id, string eventId)
        {
            Id = id;
            EventId = eventId;
            CreatedOn = DateTime.Now;
            
            _sections = new List<Section>();
        }
        
        public void AddSection(string venueId, int ordinal, double price, int rows, int columns)
        {
            var section = new Section(venueId, ordinal, price, rows, columns);
            _sections.Add(section);
        }
    }
}