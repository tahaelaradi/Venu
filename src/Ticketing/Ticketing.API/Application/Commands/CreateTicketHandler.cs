using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using Serilog;
using Ticketing.API;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.AggregatesModel.TicketAggregate;
using Venu.Ticketing.Domain.Exceptions;

namespace Venu.Ticketing.API.Application.Commands
{
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, TicketDTO>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISeatingRepository _seatingRepository;

        public CreateTicketHandler(ITicketRepository ticketRepository, ICustomerRepository customerRepository, ISeatingRepository seatingRepository)
        {
            _ticketRepository = ticketRepository;
            _customerRepository = customerRepository;
            _seatingRepository = seatingRepository;
        }

        public async Task<TicketDTO> Handle(CreateTicketCommand message, CancellationToken cancellationToken)
        {
            var seat = _seatingRepository.GetAsync(message.SeatId);
            if (seat == null) 
                throw new ArgumentNullException(nameof(seat));
            if(seat.Result.IsOccupied) 
                throw new TicketingDomainException("Seat is already occupied");
            
            var customer = _customerRepository.GetAsync(message.SeatId);
            if (seat == null) 
                throw new ArgumentNullException(nameof(seat));
            
            var ticket = new Ticket(message.SeatId, message.CustomerId);

            Log.Information($"Creating Ticket: {ticket}");
            
            _ticketRepository.Add(ticket);
            await _ticketRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            var result = new TicketDTO()
            {
                TicketId = ticket.Id,
                CreatedOn = Timestamp.FromDateTime(ticket.CreatedOn)
            };
            
            return await Task.FromResult(result);
        }
    }
}