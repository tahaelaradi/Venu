using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Venu.Ticketing.Domain.Events;

namespace Venu.Ticketing.API.Application.DomainEventHandlers.VenueSectionCreated
{
    public class AddSeatingAggregateWhenVenueSectionCreatedDomainEventHandler : INotificationHandler<VenueSectionCreatedDomainEvent>
    {
        private readonly ILogger<AddSeatingAggregateWhenVenueSectionCreatedDomainEventHandler> _logger;
        private readonly IMediator _mediator;

        public AddSeatingAggregateWhenVenueSectionCreatedDomainEventHandler(ILogger<AddSeatingAggregateWhenVenueSectionCreatedDomainEventHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(VenueSectionCreatedDomainEvent venueSectionCreatedEvent, CancellationToken cancellationToken)
        {
        }
    }
}