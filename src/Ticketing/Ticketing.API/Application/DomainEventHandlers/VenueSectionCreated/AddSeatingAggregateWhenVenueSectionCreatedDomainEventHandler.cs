using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.Events;

namespace Venu.Ticketing.API.Application.DomainEventHandlers.VenueSectionCreated
{
    public class AddSeatingAggregateWhenVenueSectionCreatedDomainEventHandler : INotificationHandler<VenueSectionCreatedDomainEvent>
    {
        private readonly ISeatingRepository _seatingRepository;
        
        public AddSeatingAggregateWhenVenueSectionCreatedDomainEventHandler(ILogger<AddSeatingAggregateWhenVenueSectionCreatedDomainEventHandler> logger, IMediator mediator, ISeatingRepository seatingRepository)
        {
            _seatingRepository = seatingRepository ?? throw new ArgumentNullException(nameof(seatingRepository));
        }

        public async Task Handle(VenueSectionCreatedDomainEvent venueSectionCreatedEvent, CancellationToken cancellationToken)
        {
            Log.Information($"VenueSectionCreatedDomainEvent happened...");
            for (var i = 1; i <= venueSectionCreatedEvent.Rows; i++)
            {
                for (var j = 1; j <= venueSectionCreatedEvent.Columns; j++)
                {
                    _seatingRepository.Add(new Seat(venueSectionCreatedEvent.VenueSectionId, i, j));
                }
            }
            
            await _seatingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}