using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.Events;

namespace Venu.Ticketing.API.Application.DomainEventHandlers.TicketCreated
{
    public class UpdateSeatOccupancyWhenTicketCreatedDomainEventHandler : INotificationHandler<TicketCreatedDomainEvent>
    {
        private readonly ISeatingRepository _seatingRepository;

        public UpdateSeatOccupancyWhenTicketCreatedDomainEventHandler(ISeatingRepository seatingRepository)
        {
            _seatingRepository = seatingRepository;
        }

        public async Task Handle(TicketCreatedDomainEvent ticketCreatedEvent, CancellationToken cancellationToken)
        {
            Log.Information($"TicketCreatedDomainEvent happened...");
            
            var seatToUpdate = await _seatingRepository.GetAsync(ticketCreatedEvent.SeatId);
            if(seatToUpdate == null)
            {
                Log.Error($"Error updating seat {ticketCreatedEvent.SeatId}; seat does not exist");
            }

            seatToUpdate?.SetIsOccupied(true);
            await _seatingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}