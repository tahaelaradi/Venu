using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Serilog;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.EventAggregate
{
    [Table("events")]
    public class Event : Entity, IAggregateRoot
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