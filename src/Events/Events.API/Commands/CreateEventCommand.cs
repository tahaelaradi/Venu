using MediatR;
using Venu.Events.API.ViewModel;

namespace Venu.Events.API.Commands
{
    public class CreateEventCommand : IRequest<Event>
    {
        public CreateEventCommand(EventInput eventInput)
        {
            this.EventInput = eventInput;
        }
        
        public EventInput EventInput { get; set; }
    }
}