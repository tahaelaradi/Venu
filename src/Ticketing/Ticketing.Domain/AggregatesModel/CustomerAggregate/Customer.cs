using System;
using System.ComponentModel.DataAnnotations.Schema;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate
{
    [Table("customers")]
    public class Customer : Entity, IAggregateRoot
    {
        public string Username { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public Customer(int id, string username)
        {
            Id = id;
            Username = username;
            CreatedOn = DateTime.Now;
        }
    }
}