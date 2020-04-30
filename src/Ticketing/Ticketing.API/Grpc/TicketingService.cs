using System;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Serilog;
using Ticketing.API;
using AppCommand = Venu.Ticketing.API.Application.Commands;
using CreateTicketCommand = Ticketing.API.CreateTicketCommand;

namespace Venu.Ticketing.API.Grpc
{
    public class TicketingService : TicketingGrpc.TicketingGrpcBase
    {
        private readonly IMediator _mediator;

        public TicketingService(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public override async Task<TicketDTO> CreateTicket(CreateTicketCommand createTicketDraft, ServerCallContext context)
        {
            Log.Information("Begin grpc call from method {Method} for ordering get order draft {CreateOrderDraftCommand}", context.Method, createTicketDraft);

            var command = new AppCommand.CreateTicketCommand(createTicketDraft.SeatId, createTicketDraft.CustomerId);

            try
            {
                var data = await _mediator.Send(command);
                return data;
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.Cancelled, $"error: {e}"));
            }
        }
    }
}