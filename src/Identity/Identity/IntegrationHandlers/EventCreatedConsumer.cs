using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Venu.BuildingBlocks.Shared.Messaging;

namespace Venu.Identity.IntegrationHandlers
{
    public class UserCreatedConsumer : IConsumer<UserCreated>
    {
        private readonly ILogger<UserCreatedConsumer> _logger;
        private readonly IMediator _mediator;

        public UserCreatedConsumer(ILogger<UserCreatedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            _logger.LogInformation($"UserCreatedConsumer happened: Username: {context.Message.Username}");
            
            await Task.Delay(10);
            await Task.FromResult(0);
        }
    }
}
