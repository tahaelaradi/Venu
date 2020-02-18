using System;
using System.Threading.Tasks;
using MassTransit;
using Venu.Events.IntegrationEvents;

namespace Venu.Events.IntegrationHandlers
{
    public class EventCreatedConsumer : IConsumer<EventCreated>
    {
        public async Task Consume(ConsumeContext<EventCreated> context)
        {
            await Console.Out.WriteLineAsync($"Event created: {context.Message.Name}");
        }
    }
}
