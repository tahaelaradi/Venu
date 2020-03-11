using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Domain;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Commands.Handlers
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, EventDto>
    {
        private readonly IRepository _eventRepository;

        public CreateEventHandler(IRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        public async Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var draft = Event.CreateDraft
            (
                request.EventInput.Name
            );

            await _eventRepository.AddOneAsync(draft);

            return new EventDto
            {
                Id = draft.Id,
                Name = draft.Name
            };
        }
    }
}