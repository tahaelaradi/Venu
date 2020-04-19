using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Ticketing.API.Commands;
using Venu.Ticketing.API.Commands.Dtos;

namespace Venu.Ticketing.API.IntegrationHandlers
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
            
            var eventInput = new EventInput(context.Message.Id, context.Message.Name);
            _logger.LogInformation($"EventCreatedConsumer happened: Event name: {eventInput}");
            await _mediator.Send(new CreateEventCommand(eventInput));

            await Task.Delay(10);
            await Task.FromResult(0);
        }
    }
}