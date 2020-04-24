using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Ticketing.API.Application.Commands;
using Venu.Ticketing.API.Extensions.Converters;

namespace Venu.Ticketing.API.Application.IntegrationHandlers
{
    public class EventCreatedConsumer : IConsumer<EventCreated>
    {
        private readonly ILogger<EventCreatedConsumer> _logger;
        private readonly IMediator _mediator;

        public EventCreatedConsumer(ILogger<EventCreatedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<EventCreated> context)
        {
            Log.Information($"EventCreatedConsumer happened: Event name: {context.Message.Name}");

            await _mediator.Send(new CreateEventCommand(
                context.Message.EventId,
                context.Message.VenueId,
                context.Message.Name,
                context.Message.VenueSections
            ));
            await Task.FromResult(0);
        }
    }
}