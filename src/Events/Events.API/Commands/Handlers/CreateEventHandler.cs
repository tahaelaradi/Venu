using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Events.API.Domain;
using Venu.Events.API.Extensions.Converters;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Commands.Handlers
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, EventDto>
    {
        private readonly IBusControl _bus;

        private readonly IRepository _eventRepository;
        private readonly IRepository _venueRepository;

        public CreateEventHandler(
            IBusControl bus,
            IRepository eventRepository,
            IRepository venueRepository
        )
        {
            _bus = bus;
            _eventRepository = eventRepository;
            _venueRepository = venueRepository;
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
                request.EventInput.IsFree,
                request.EventInput.Address.ToContract(),
                request.EventInput.Image.ToContract()
            );

            await _eventRepository.AddOneAsync(evenDraft);

            await _bus.Publish<EventCreated>(new
            {
                EventId = evenDraft.Id,
                VenueId = venueDraft?.Id,
                Name = evenDraft.Name,
                VenueSections = venueDraft?.Sections.ToVenueSectionsCreated().ToList()
            }, cancellationToken);

            return new EventDto
            {
                Id = evenDraft.Id,
                Name = evenDraft.Name
            };
        }
    }
}