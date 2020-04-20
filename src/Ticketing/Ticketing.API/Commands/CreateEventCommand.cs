using MediatR;
using Venu.Ticketing.API.Commands.Dtos;
using Venu.Ticketing.API.Queries.Dtos;

namespace Venu.Ticketing.API.Commands
{
    public class CreateEventCommand : IRequest
    {
        public CreateEventCommand(EventInput eventInput)
        {
            this.EventInput = eventInput;
        }
        
        public EventInput EventInput { get; private set; }
    }
}