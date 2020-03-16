using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Domain;
using Venu.Events.API.Extensions.Converters;
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
            // TODO: Deconstruct EventInput from request
            var draft = Event.CreateDraft
            (
                request.EventInput.Name,
                request.EventInput.Type,
                request.EventInput.Category,
                request.EventInput.Url,
                request.EventInput.PrimaryOrganizerId,
                request.EventInput.Summary,
                request.EventInput.StartDate,
                request.EventInput.EndDate,
                request.EventInput.VenueId,
                request.EventInput.Tags,
                request.EventInput.HasVenue,
                request.EventInput.IsFree,
                request.EventInput.Address.ToContract(),
                request.EventInput.Image.ToContract()
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