using System;
using System.Threading.Tasks;
using MassTransit;
using Venu.Events.API.IntegrationEvents;

namespace Venu.Events.API.IntegrationHandlers
{
    public class EventCreatedConsumer : IConsumer<EventCreated>
    {
        public async Task Consume(ConsumeContext<EventCreated> context)
        {
            await Console.Out.WriteLineAsync($"Event created: {context.Message.Name}");
        }
    }
}
