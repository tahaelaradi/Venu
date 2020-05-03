using System;
using System.ComponentModel.DataAnnotations.Schema;
using Venu.Ticketing.Domain.Events;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.TicketAggregate
{
    [Table("tickets")]
    public class Ticket : Entity, IAggregateRoot
    {
        public string Id { get; set; }
        public int SeatId { get; set; }
        public int CustomerId { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        
        public Ticket(int seatId, int customerId)
        {
            Id = Guid.NewGuid().ToString();
            SeatId = seatId;
            CustomerId = customerId;
            CreatedOn = DateTime.UtcNow;

            this.UpdateSeat(seatId);
        }

        private void UpdateSeat(int seatId)
        {
            var ticketCreatedDomainEvent = new TicketCreatedDomainEvent(seatId);
            AddDomainEvent(ticketCreatedDomainEvent);
        }
    }
}