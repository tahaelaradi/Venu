using MediatR;

namespace Venu.Ticketing.Domain.Events
{
    public class TicketCreatedDomainEvent : INotification
    {
        public int SeatId { get; }

        public TicketCreatedDomainEvent(int seatId)
        {
            SeatId = seatId;
        }
    }
}