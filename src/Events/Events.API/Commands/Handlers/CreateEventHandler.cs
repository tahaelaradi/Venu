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
            var venueDraft = request.EventInput.Venue == null
                ? null
                : Venue.CreateDraft(
                    request.EventInput.Venue.Name,
                    request.EventInput.Venue.Sections.ToContract()
                );

            if (request.EventInput.Venue != null) await _venueRepository.AddOneAsync(venueDraft);

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
                venueDraft == null ? string.Empty : venueDraft.Id,
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