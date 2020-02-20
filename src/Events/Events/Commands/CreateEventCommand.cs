using MediatR;
using Venu.Events.Commands.Dtos;
using Venu.Events.Queries.Dtos;

namespace Venu.Events.Commands
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