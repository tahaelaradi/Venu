using System;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Commands;
using Venu.Events.API.ViewModel;

namespace Venu.Events.API.GraphType.Mutations
{
    public class Mutation
    {
        private readonly IMediator _mediator;
        public Mutation(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Event> CreateNewEvent(EventInput eventInput)
        {
            return await _mediator.Send(new CreateEventCommand(eventInput));
        }
    }
}