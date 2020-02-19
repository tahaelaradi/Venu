using System.Threading.Tasks;
using MediatR;
using Venu.Events.Commands;
using Venu.Events.Commands.Dtos;
using Venu.Events.Queries.Dtos;

namespace Venu.Events.GraphType.Mutations
{
    public class Mutations
    {
        private readonly IMediator _mediator;
        public Mutations(IMediator mediator)
        {
            _mediator = mediator;
        }

        // public async Task<CreateEventDraftResult> CreateNewEvent(EventDraftDto eventInput)
        // {
        //     return await _mediator.Send(new CreateEventDraftCommand(eventInput));
        // }
    }
}