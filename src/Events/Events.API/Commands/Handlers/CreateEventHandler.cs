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
        private readonly IRepository _venueRepository;

        public CreateEventHandler(
            IRepository eventRepository,
            IRepository _venueRepository
        )
        {
            this._eventRepository = eventRepository;
            this._venueRepository = _venueRepository;
        }

        public async Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var venueDraft = Venue.CreateDraft(request.EventInput.Venue.Name);

            await _venueRepository.AddOneAsync(venueDraft);

            // TODO: Deconstruct EventInput from request
            var evenDraft = Event.CreateDraft
            (
                request.EventInput.Name,
                request.EventInput.Type,
                request.EventInput.Category,
                request.EventInput.Url,
                request.EventInput.PrimaryOrganizerId,
                request.EventInput.Summary,
                request.EventInput.StartDate,
                request.EventInput.EndDate,
                venueDraft.Id,
                request.EventInput.Tags,
                request.EventInput.HasVenue,
                request.EventInput.IsFree,
                request.EventInput.Address.ToContract(),
                request.EventInput.Image.ToContract()
            );

            await _eventRepository.AddOneAsync(evenDraft);

            return new EventDto
            {
                Id = evenDraft.Id,
                Name = evenDraft.Name
            };
        }
    }
}