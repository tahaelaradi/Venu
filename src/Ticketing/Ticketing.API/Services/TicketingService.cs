using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Ticketing.API;

namespace Venu.Ticketing.API.Services
{
    public class TicketingService : TicketingGrpc.TicketingGrpcBase
    {
        private readonly ILogger<TicketingService> _logger;

        public TicketingService(ILogger<TicketingService> logger)
        {
            _logger = logger;
        }
        
        public override Task<TicketDraftDTO> CreateTicket(CreateTicketDraftCommand request, ServerCallContext context)
        {
            return Task.FromResult(new TicketDraftDTO
            {
                TicketId = "1234",
                CreatedOn = Timestamp.FromDateTime(DateTime.UtcNow)
            });
        }
    }
}