using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venu.Ticketing.Domain.AggregatesModel.EventAggregate
{
    [Table("Event")]
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public Event(string id, string name)
        {
            Id = id;
            Name = name;
            IsActive = false;
            CreatedOn = DateTime.Now;
        }
    }
}