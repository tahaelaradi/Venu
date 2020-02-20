using System.Threading.Tasks;
using MediatR;
using Venu.Events.Commands;
using Venu.Events.Commands.Dtos;
using Venu.Events.Queries.Dtos;

namespace Venu.Events.GraphType.Mutations
{
    public class Mutation
    {
        private readonly IMediator _mediator;
        public Mutation(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EventDto> CreateNewEvent(EventInput eventInput)
        {
            return await _mediator.Send(new CreateEventCommand(eventInput));
        }
    }
}