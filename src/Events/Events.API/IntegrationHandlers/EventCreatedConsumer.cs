using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Venu.BuildingBlocks.Shared.Messaging;

namespace Venu.Events.API.IntegrationHandlers
{
    public class EventCreatedConsumer : IConsumer<EventCreated>
    {
        private readonly ILogger<EventCreatedConsumer> _logger;

        public EventCreatedConsumer(ILogger<EventCreatedConsumer> logger)
        {
            _logger = logger;
        }

        public EventCreatedConsumer()
        {
        }

        public async Task Consume(ConsumeContext<EventCreated> context)
        {
            _logger.LogInformation($"Event created: {context.Message.Name}");

            await Task.Delay(10);
            await Task.FromResult(0);
        }
    }
}
