using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Ticketing.API.Application.Commands;

namespace Venu.Ticketing.API.Application.IntegrationHandlers
{
    public class CustomerCreatedConsumer : IConsumer<UserCreated>
    {
        private readonly ILogger<CustomerCreatedConsumer> _logger;
        private readonly IMediator _mediator;

        public CustomerCreatedConsumer(ILogger<CustomerCreatedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            Log.Information($"CustomerCreatedConsumer happened: Username: {context.Message.Username}");

            await _mediator.Send(new CreateCustomerCommand(context.Message.Id, context.Message.Username));
            await Task.FromResult(0);
        }
    }
}