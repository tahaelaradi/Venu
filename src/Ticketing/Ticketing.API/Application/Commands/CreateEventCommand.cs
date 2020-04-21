using MediatR;

namespace Venu.Ticketing.API.Application.Commands
{
    public class CreateEventCommand : IRequest
    {
        public CreateEventCommand(EventInput eventInput)
        {
            this.EventInput = eventInput;
        }
        
        public EventInput EventInput { get; private set; }
    }
    
    public class EventInput
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public EventInput(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}