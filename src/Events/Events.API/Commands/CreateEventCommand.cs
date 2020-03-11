using MediatR;
using Venu.Events.API.Commands.Dtos;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Commands
{
    public class CreateEventCommand : IRequest<EventDto>
    {
        public CreateEventCommand(EventInput eventInput)
        {
            this.EventInput = eventInput;
        }
        
        public EventInput EventInput { get; set; }
    }
}