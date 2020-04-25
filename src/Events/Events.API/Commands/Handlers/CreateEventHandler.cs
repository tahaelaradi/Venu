using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Events.API.Infrastructure.Extensions.Converters;
using Venu.Events.API.Models;
using Event = Venu.Events.API.ViewModel.Event;

namespace Venu.Events.API.Commands.Handlers
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, Event>
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

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var venueDraft = request.EventInput.Venue == null
                ? null
                : Venue.CreateDraft(
                    request.EventInput.Venue.Name,
                    request.EventInput.Venue.Sections.ToContract()
                );

            if (request.EventInput.Venue != null) await _venueRepository.AddOneAsync(venueDraft);

            var evenDraft = Models.Event.CreateDraft
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
                EventConverters.ToContract(request.EventInput.Address),
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

            return new Event
            {
                Id = evenDraft.Id,
                Name = evenDraft.Name
            };
        }
    }
}