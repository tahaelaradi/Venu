using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Ticketing.API.Application.Commands;

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
            _logger.LogInformation($"EventCreatedConsumer happened: Event name: {context.Message.Name}");
            
            await _mediator.Send(new CreateEventCommand(new EventInput(context.Message.Id, context.Message.Name)));
            await Task.FromResult(0);
        }
    }
}