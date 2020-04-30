using System.Runtime.Serialization;
using MediatR;
using Ticketing.API;

namespace Venu.Ticketing.API.Application.Commands
{
    [DataContract]
    public class CreateTicketCommand :  IRequest<TicketDTO>
    {
        [DataMember] 
        public int SeatId { get; set; }
        
        [DataMember] 
        public int CustomerId { get; set; }
        
        public CreateTicketCommand(int seatId, int customerId)
        {
            SeatId = seatId;
            CustomerId = customerId;
        }
    }
}